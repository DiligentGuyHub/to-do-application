using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Domain.Exceptions
{
    public class InvalidLoginOrPasswordException : Exception
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public InvalidLoginOrPasswordException(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public InvalidLoginOrPasswordException(string message, string username, string password) : base(message)
        {
            Username = username;
            Password = password;
        }

        public InvalidLoginOrPasswordException(string message, Exception innerException, string username, string password) : base(message, innerException)
        {
            Username = username;
            Password = password;
        }
    }
}
