using AutoMapper;
using Build_IT_Application.Mapping.Interfaces;
using Build_IT_Application.ScriptInterpreter.Tags.Queries;
using Build_IT_CommonTools.Interfaces;
using Build_IT_Data.Entities.Scripts;
using Build_IT_Data.Entities.Scripts.Enums;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.Scripts.Commands.CreateScript
{
    public class CreateScriptCommand : IRequest<ScriptCreated>
    {
        #region Properties

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string GroupName { get; set; }
        public string Author { get; set; }
        public string AccordingTo { get; set; }
        public string Notes { get; set; }
        public Language DefaultLanguage { get; set; }
        public ICollection<TagResource> Tags { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<CreateScriptCommand, ScriptCreated>
        {
            #region Fields

            private readonly IDateTime _dateTime;
            private readonly IScriptRepository _scriptRepository;
            private readonly IScriptInterpreterUnitOfWork _unitOfWork;
            private readonly IMediator _mediator;

            #endregion // Fields

            #region Constructors

            public Handler(
                IDateTime dateTime,
                IScriptRepository scriptRepository,
                IScriptInterpreterUnitOfWork unitOfWork,
                IMediator mediator)
            {
                _dateTime = dateTime;
                _scriptRepository = scriptRepository;
                _unitOfWork = unitOfWork;
                _mediator = mediator;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<ScriptCreated> Handle(CreateScriptCommand request, CancellationToken cancellationToken)
            {
                var script = new Script
                {
                    Id = 0,
                    Name = request.Name,
                    Description = request.Description,
                    GroupName = request.GroupName,
                    Author = request.Author,
                    AccordingTo = request.AccordingTo,
                    Notes = request.Notes,
                    DefaultLanguage = request.DefaultLanguage,
                    Added = _dateTime.Now,
                    Modified = _dateTime.Now,
                    Version = "1"
                };
                RemoveNotAddedTags(request, script);
                AddNewTags(request, script);

                await _scriptRepository.AddAsync(script);

                await _unitOfWork.CompleteAsync(cancellationToken);

                await _mediator.Publish(new ScriptCreated { Id = script.Id }, cancellationToken);

                // return Unit.Value; HACK: Needs to be this
                return new ScriptCreated { Id = script.Id };
            }

            #endregion // Public_Methods
            
            #region Private_Methods
            
            private void AddNewTags(CreateScriptCommand request, Script script)
            {
                var addedTags = request.Tags.Where(tr => !script.Tags.Any(t => t.TagId == tr.Id))
                     .Select(tr => new ScriptTag { TagId = tr.Id }).ToList();
                foreach (var tag in addedTags)
                    script.Tags.Add(tag);
            }

            private void RemoveNotAddedTags(CreateScriptCommand request, Script script)
            {
                var removedTags = script.Tags.Where(t =>
                !request.Tags.Select(tr => tr.Id).Contains(t.TagId)).ToList();
                foreach (var tag in removedTags)
                    script.Tags.Remove(tag);
            }

            #endregion // Private_Methods
        }
    }
}
