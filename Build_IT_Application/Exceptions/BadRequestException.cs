using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Application.Exceptions
{
    public class BadRequestException : Exception
    {
        #region Constructors

        public BadRequestException(string name, object key)
            : base($"Entity \"{name}\" ({key}) result in bad request.")
        {
        }

        #endregion // Constructors
    }
}
