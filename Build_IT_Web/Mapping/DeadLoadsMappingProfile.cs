using AutoMapper;
using Build_IT_DataAccess.DeadLoads.Models;
using Build_IT_Web.Controllers.DeadLoadsControllers.Resources;

namespace Build_IT_Web.Mapping
{
    public class DeadLoadsMappingProfile : Profile
    {
        public DeadLoadsMappingProfile()
        {
            CreateMap<CategoryResource, Category>();
            CreateMap<Category, CategoryResource>();
        }
    }
}
