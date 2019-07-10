using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Application.Exceptions
{
    public class NotFoundException : Exception
    {
        #region Constructors

        public NotFoundException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }

        #endregion // Constructors
    }
}
