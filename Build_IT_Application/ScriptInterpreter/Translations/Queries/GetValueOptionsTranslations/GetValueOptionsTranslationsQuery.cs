using AutoMapper;
using Build_IT_Data.Entities.Scripts.Enums;
using Build_IT_Data.Entities.Scripts.Translations;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.Translations.Queries.GetValueOptionsTranslations
{
    public class GetValueOptionsTranslationsQuery : IRequest<IEnumerable<ValueOptionTranslationResource>>
    {
        #region Properties
        
        public long ParameterId { get; set; }
        public Language Language { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<GetValueOptionsTranslationsQuery, IEnumerable<ValueOptionTranslationResource>>
        {
            #region Fields

            private readonly IMapper _mapper;
            private readonly IValueOptionTranslationRepository _translationRepository;
            private readonly IScriptInterpreterUnitOfWork _unitOfWork;

            #endregion // Fields

            #region Constructors

            public Handler(
            IValueOptionTranslationRepository translationRepository,
            IScriptInterpreterUnitOfWork unitOfWork,
            IMapper mapper)
            {
                _mapper = mapper;
                _translationRepository = translationRepository;
                _unitOfWork = unitOfWork;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<IEnumerable<ValueOptionTranslationResource>> Handle(GetValueOptionsTranslationsQuery request, CancellationToken cancellationToken)
            {
                var valueOptionsTranslations = await _translationRepository.GetValueOptionsTranslations(request.ParameterId, request.Language);
                var valueOptionsTranslationsResources = _mapper.Map<IEnumerable<ValueOptionTranslation>, IEnumerable<ValueOptionTranslationResource>>(valueOptionsTranslations);

                return valueOptionsTranslationsResources;
            }

            #endregion // Public_Methods
        }
    }
}
