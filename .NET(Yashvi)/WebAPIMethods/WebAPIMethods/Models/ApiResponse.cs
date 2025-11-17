namespace WebApiDemo.Models
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiResponse(int statusCode, bool isSuccess, string message, T data = default)
        {
            StatusCode = statusCode;
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }
    }
}
