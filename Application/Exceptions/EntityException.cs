using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using FluentValidation.Results;

namespace Application.Exceptions
{
    public class EntityException : Exception
    {
        public EntityException(string message) : base(message)
        {
        }

        public EntityException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
