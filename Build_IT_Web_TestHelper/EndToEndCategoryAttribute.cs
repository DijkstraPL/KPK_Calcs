using NUnit.Framework;
using System;

namespace Build_IT_Web_TestHelper
{
    public class EndToEndCategoryAttribute : CategoryAttribute
    {
        public EndToEndCategoryAttribute() : base("EndToEnd")
        {
        }
    }
}
