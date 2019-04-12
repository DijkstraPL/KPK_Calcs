using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Data.Sections
{
    public class SectionProperties : Section
    {
        #region Constructors

        public SectionProperties(double area, double momentOfInteria) : base()
        {
            Area = area;
            MomentOfInteria = momentOfInteria;
        }

        #endregion // Constructors

        #region Public_Methods

        public override void SetSectionProperties()
        {
        }

        #endregion // Public_Methods
    }
}
