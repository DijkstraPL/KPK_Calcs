using AutoMapper;
using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.Tags.Queries.GetAllTagsForScript
{
    public class GetAllTagsForScriptQuery : IRequest<IEnumerable<TagResource>>
    {
        #region Properties

        public long ScriptId { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<GetAllTagsForScriptQuery, IEnumerable<TagResource>>
        {
            #region Fields

            private readonly ITagRepository _tagRepository;
            private readonly IMapper _mapper;

            #endregion // Fields

            #region Constructors

            public Handler(ITagRepository tagRepository,
                IMapper mapper)
            {
                _tagRepository = tagRepository;
                _mapper = mapper;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<IEnumerable<TagResource>> Handle(GetAllTagsForScriptQuery request, CancellationToken cancellationToken)
            {
                var tags = await _tagRepository.GetTagsForScriptAsync(request.ScriptId);

                return _mapper.Map<IEnumerable<Tag>, IEnumerable<TagResource>>(tags.OrderBy(t => t.Name));
            }

            #endregion // Public_Methods
        }
    }
}
