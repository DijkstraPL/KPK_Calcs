using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.Tags.Commands.CreateTag
{
    public class CreateTagCommand : IRequest<TagCreated>
    {
        #region Properties
        
        public long Id { get; set; }
        public string Name { get; set; }

        #endregion // Properties

        public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, TagCreated>
        {
            #region Fields

            private readonly ITagRepository _tagRepository;
            private readonly IScriptInterpreterUnitOfWork _unitOfWork;

            #endregion // Fields

            #region Constructors

            public CreateTagCommandHandler(
                ITagRepository tagRepository,
                IScriptInterpreterUnitOfWork unitOfWork)
            {
                _tagRepository =  tagRepository;
                _unitOfWork = unitOfWork;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<TagCreated> Handle(CreateTagCommand request, CancellationToken cancellationToken)
            {
                var tag = new Tag
                {
                    Id = 0,
                    Name = request.Name
                };

                await _tagRepository.AddAsync(tag);

                await _unitOfWork.CompleteAsync(cancellationToken);

                return new TagCreated { Id = tag.Id };
            }

            #endregion // Public_Methods
        }
    }
}
