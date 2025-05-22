namespace Management_Schedule_BE.Common
{
    public class CommonResponse<T>
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public object Errors { get; set; }

        public CommonResponse(string status, string message, T data = default, object errors = null)
        {
            Status = status;
            Message = message;
            Data = data;
            Errors = errors;
        }
    }
} 