using System.Net;

namespace CompanyModule.Domain
{
    [Serializable]
    internal class ServiceResponseException : Exception
    {
        private HttpStatusCode internalServerError;
        private string v;

        public ServiceResponseException()
        {
        }

        public ServiceResponseException(string? message) : base(message)
        {
        }

        public ServiceResponseException(HttpStatusCode internalServerError, string v)
        {
            this.internalServerError = internalServerError;
            this.v = v;
        }

        public ServiceResponseException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}