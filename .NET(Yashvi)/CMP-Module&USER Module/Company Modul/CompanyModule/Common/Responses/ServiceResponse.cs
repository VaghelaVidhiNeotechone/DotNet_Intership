
using CompanyModule.Common.Responses;
namespace CompanyModule.Common.Responses
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; }

        public string Message { get; set; } = string.Empty;

        public T? DataResult { get; set; }

        public int StatusCode { get; set; }

        public List<string> Errors { get; set; } = new();

        public static ServiceResponse<T> Ok(T data, string message = "Success")
        {
            return new ServiceResponse<T>
            {
                Success = true,
                DataResult = data,
                Message = message,
                StatusCode = 200
            };
        }

        public static ServiceResponse<T> Fail(string message, int statusCode = 400)
        {
            return new ServiceResponse<T>
            {
                Success = false,
                Message = message,
                StatusCode = statusCode
            };
        }

        public static ServiceResponse<T> SuccessResponse(T data, string message = "Success")
        {
            return Ok(data, message);
        }
    }
}
