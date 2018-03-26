using System;

namespace Airports.Base.Exceptions
{
    public class ItemNotFoundException: AirportException
    {
        public ItemNotFoundException(string message = GlobalVariables.ErrorMessages.ItemNotFoundException): base(message){}
    }
}
