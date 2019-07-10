using AutoMapper;
using Build_IT_Data.Entities.DeadLoads;
using Build_IT_DataAccess.DeadLoads.Repositories.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.DeadLoads.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<CategoryResource>>
    {
        public class Handler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryResource>>
        {
            #region Fields

            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;

            #endregion // Fields

            #region Constructors

            public Handler(ICategoryRepository categoryRepository,
                IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<IEnumerable<CategoryResource>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
            {
                var categories = await _categoryRepository.GetAllAsync(cancellationToken);

                return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
            }

            #endregion // Public_Methods
        }
    }
}
