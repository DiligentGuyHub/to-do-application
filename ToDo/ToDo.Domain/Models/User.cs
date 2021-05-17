using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Domain.Models
{
    public class User : DomainBase
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public bool Status { get; set; }
        public DateTime DateJoined { get; set; }
        public ICollection<Task> Tasks { get; set; }    

    }
}
