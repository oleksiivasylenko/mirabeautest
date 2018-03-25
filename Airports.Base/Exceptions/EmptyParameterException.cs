using System;

namespace Airports.Base.Exceptions
{
    public class EmptyParameterException: Exception
    {
        public EmptyParameterException(string message = GlobalVariables.ErrorMessages.EmptyParameterException) : base(message) { }
    }
}
