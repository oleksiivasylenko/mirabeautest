using System;

namespace Airports.Base.Exceptions
{
    public class ItemNotFoundException: Exception
    {
        public ItemNotFoundException(string message = GlobalVariables.ErrorMessages.ItemNotFoundException): base(message){}
    }
}
