using AutoMapper;
using Build_IT_DataAccess.DeadLoads.Models;
using Build_IT_Web.Controllers.DeadLoadsControllers.Resources;
using System.Linq;

namespace Build_IT_Web.Mapping
{
    public class DeadLoadsMappingProfile : Profile
    {
        #region Constructors
        
        public DeadLoadsMappingProfile()
        {
            CreateMap<Category, CategoryResource>();
            CreateMap<Subcategory, SubcategoryResource>();
            CreateMap<Material, MaterialResource>()
                .ForMember(m => m.Additions, operation
                => operation.MapFrom(mr => mr.MaterialAdditions.Select(ma => ma.Addition)));

            CreateMap<CategoryResource, Category>();
            CreateMap<SubcategoryResource, Subcategory>();
            CreateMap<MaterialResource, Material>()
                .ForMember(mr => mr.MaterialAdditions, operation => operation.Ignore())
                .AfterMap((mr, m) =>
                {
                    RemoveNotAddedAdditions(mr, m);
                    AddNewAdditions(mr, m);
                });
        }

        #endregion // Constructors

        #region Private_Methods

        private void RemoveNotAddedAdditions(MaterialResource materialResource, Material material)
        {
            var removedAdditions = material.MaterialAdditions.Where(ma =>
            !materialResource.Additions.Select(a => a.Id).Contains(ma.AdditionId)).ToList();
            foreach (var addition in removedAdditions)
                material.MaterialAdditions.Remove(addition);
        }

        private void AddNewAdditions(MaterialResource materialResource, Material material)
        {
            var addedAdditions = materialResource.Additions.Where(a =>
            !material.MaterialAdditions.Any(ma => ma.AdditionId == a.Id))
                 .Select(a => new MaterialAddition { AdditionId = a.Id }).ToList();
            foreach (var addition in addedAdditions)
                material.MaterialAdditions.Add(addition);
        }

        #endregion // Private_Methods
    }
}
