using Build_IT_Application.Exceptions;
using Build_IT_Application.ScriptInterpreter.Tags.Queries;
using Build_IT_CommonTools.Interfaces;
using Build_IT_Data.Entities.Scripts;
using Build_IT_Data.Entities.Scripts.Enums;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.Scripts.Commands.UpdateScript
{
    public class UpdateScriptCommand : IRequest
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
        public bool IsPublic { get; set; }
        public bool IsAdmin { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<UpdateScriptCommand, Unit>
        {
            #region Fields

            private readonly IDateTime _dateTime;
            private readonly IScriptRepository _scriptRepository;
            private readonly IScriptInterpreterUnitOfWork _unitOfWork;

            #endregion // Fields

            #region Constructors

            public Handler(
                IDateTime dateTime,
                IScriptRepository scriptRepository,
                IScriptInterpreterUnitOfWork unitOfWork)
            {
                _dateTime = dateTime;
                _scriptRepository = scriptRepository;
                _unitOfWork = unitOfWork;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<Unit> Handle(UpdateScriptCommand request, CancellationToken cancellationToken)
            {
                var script = await _scriptRepository.GetScriptWithTagsAsync(request.Id);

                if (script.Author != request.Author && !request.IsAdmin)
                    throw new ValidationException();

                if (script == null)
                    throw new NotFoundException(nameof(Script), request.Id);

                script.Id = request.Id;
                script.Name = request.Name;
                script.Description = request.Description;
                script.GroupName = request.GroupName;
                script.Author = request.Author;
                script.AccordingTo = request.AccordingTo;
                script.Notes = request.Notes;
                script.DefaultLanguage = request.DefaultLanguage;
                script.IsPublic = request.IsPublic;
                script.Modified = _dateTime.Now;

                RemoveNotAddedTags(request, script);
                AddNewTags(request, script);

                await _unitOfWork.CompleteAsync();

                return Unit.Value;
            }

            #endregion // Public_Methods

            #region Private_Methods

            private void AddNewTags(UpdateScriptCommand request, Script script)
            {
                var addedTags = request.Tags.Where(tr => !script.Tags.Any(t => t.TagId == tr.Id))
                     .Select(tr => new ScriptTag { TagId = tr.Id }).ToList();
                foreach (var tag in addedTags)
                    script.Tags.Add(tag);
            }

            private void RemoveNotAddedTags(UpdateScriptCommand request, Script script)
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
