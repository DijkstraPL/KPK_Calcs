using AutoMapper;
using Build_IT_Data.Entities.DeadLoads;
using Build_IT_DataAccess.DeadLoads.Interfaces;
using Build_IT_DataAccess.DeadLoads.Repositories.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.DeadLoads.Subcategories.Queries.GetAllSubcategories
{
    public class GetAllSubcategoriesQuery : IRequest<List<SubcategoryResource>>
    {
        #region Properties
               
        public long CategoryId { get; set; }

        #endregion // Properties        

        public class Handler : IRequestHandler<GetAllSubcategoriesQuery, List<SubcategoryResource>>
        {
            #region Fields

            private readonly ISubcategoryRepository _subcategoryRepository;
            private readonly IMapper _mapper;

            #endregion // Fields

            #region Constructors

            public Handler(ISubcategoryRepository subcategoryRepository,
                IMapper mapper)
            {
                _subcategoryRepository = subcategoryRepository;
                _mapper = mapper;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<List<SubcategoryResource>> Handle(GetAllSubcategoriesQuery request, CancellationToken cancellationToken)
            {
                var subcategories = await _subcategoryRepository.GetAllSubcategoriesForCategoryAsync(request.CategoryId, cancellationToken);

                return _mapper.Map<List<Subcategory>, List<SubcategoryResource>>(subcategories);
            }

            #endregion // Public_Methods
        }
    }
}
