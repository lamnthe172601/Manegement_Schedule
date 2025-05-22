namespace Management_Schedule_BE.Common
{
    public class CommonResponse<T>
    {
        public string status { get; set; }
        public string message { get; set; }
        public T data { get; set; }
        public object errors { get; set; }

        public CommonResponse(string _status, string _message, T _data = default, object _errors = null)
        {
            status = _status;
            message = _message;
            data = _data;
            errors = _errors;
        }
    }
} 