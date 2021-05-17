using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Domain.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public string Username { get; set; }
        public UserNotFoundException(string username, string password)
        {
            Username = username;
        }

        public UserNotFoundException(string message, string username, string password) : base(message)
        {
            Username = username;
        }

        public UserNotFoundException(string message, Exception innerException, string username, string password) : base(message, innerException)
        {
            Username = username;
        }
    }
}
