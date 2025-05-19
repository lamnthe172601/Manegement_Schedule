using System;

namespace Management_Schedule_BE.Services.Exceptions
{
    public class ServiceException : Exception
    {
        public ServiceException()
        {
        }

        public ServiceException(string message) : base(message)
        {
        }

        public ServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class NotFoundException : ServiceException
    {
        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string name, object key) 
            : base($"Không tìm thấy \"{name}\" với mã \"{key}\".")
        {
        }
    }

    public class ValidationException : ServiceException
    {
        public ValidationException(string message) : base(message)
        {
        }
    }
} 