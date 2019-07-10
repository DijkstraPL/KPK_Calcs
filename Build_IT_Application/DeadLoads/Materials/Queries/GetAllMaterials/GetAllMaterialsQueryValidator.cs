using FluentValidation;

namespace Build_IT_Application.DeadLoads.Materials.Queries.GetAllMaterials
{
    public class GetAllMaterialsQueryValidator : AbstractValidator<GetAllMaterialsQuery>
    {
        #region Constructors

        public GetAllMaterialsQueryValidator()
        {
            RuleFor(v => v.SubcategoryId)
                .NotEmpty()
                .GreaterThan(0);
        }

        #endregion // Constructors
    }
}
