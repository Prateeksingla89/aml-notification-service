using System;
using System.Collections.Generic;

namespace Aml.Notification.Service.Exceptions
{
    public class ValidationException:Exception
    {
        public ValidationException(IEnumerable<string> messages, Exception ex = null) 
        {
        }

        public ValidationException(string message, Exception ex = null)
        {
        }
    }
}
