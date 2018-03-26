using System;

namespace Airports.Base.Exceptions
{
    public class EmptyParameterException: AirportException
    {
        public EmptyParameterException(string message = GlobalVariables.ErrorMessages.EmptyParameterException) : base(message) { }
    }
}
