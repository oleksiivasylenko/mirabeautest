namespace Airports.Base.ViewModels
{
    public class Response<T>
    {
        #region props

        public bool Success { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }

        #endregion

        #region ctors

        public Response()
        {
            Success = true;
        }

        public Response(T data, bool success = true): this()
        {
            Data = data;
            Success = success;
        }

        public Response(string message, bool success = false) : this()
        {
            Message = message;
            Success = success;
        }

        #endregion
    }
}
