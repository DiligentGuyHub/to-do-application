using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Models;

namespace ToDo.Domain.Services
{
    public interface IAccountService : IDataService<User>
    {
        Task<User> GetByUsername(string username);
        Task<User> GetByEmail(string email);
    }
}
