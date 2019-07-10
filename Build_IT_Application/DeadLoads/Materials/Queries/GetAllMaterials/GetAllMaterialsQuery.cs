using AutoMapper;
using Build_IT_Data.Entities.DeadLoads;
using Build_IT_DataAccess.DeadLoads.Repositories.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.DeadLoads.Materials.Queries.GetAllMaterials
{
    public class GetAllMaterialsQuery : IRequest<List<MaterialResource>>
    {
        #region Properties

        public long SubcategoryId { get; set; }

        #endregion // Properties
        
        public class Handler : IRequestHandler<GetAllMaterialsQuery, List<MaterialResource>>
        {
            #region Fields

            private readonly IMaterialRepository _materialRepository;
            private readonly IMapper _mapper;

            #endregion // Fields

            #region Constructors

            public Handler(IMaterialRepository materialRepository,
                IMapper mapper)
            {
                _materialRepository = materialRepository;
                _mapper = mapper;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<List<MaterialResource>> Handle(GetAllMaterialsQuery request, CancellationToken cancellationToken)
            {
                var materials = await _materialRepository.GetAllMaterialsForSubcategoryAsync(
                    request.SubcategoryId, cancellationToken);

                return _mapper.Map<List<Material>, List<MaterialResource>>(materials);
            }

            #endregion // Public_Methods
        }
    }
}
