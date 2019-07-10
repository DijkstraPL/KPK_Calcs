using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Application.DeadLoads.Subcategories.Queries.GetAllSubcategories
{
    public class GetAllSubcategoriesQueryValidator : AbstractValidator<GetAllSubcategoriesQuery>
    {
        #region Constructors

        public GetAllSubcategoriesQueryValidator()
        {
            RuleFor(v => v.CategoryId)
                .NotEmpty()
                .GreaterThan(0);
        }

        #endregion // Constructors
    }
}
