using System;

namespace Airports.Base.Exceptions
{
    public class AirportException : Exception
    {
        public AirportException()
        {

        }

        public AirportException(string message) : base(message)
        {

        }
    }
}
