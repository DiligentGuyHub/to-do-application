using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Models;

namespace ToDo.Domain.Services
{
    public interface ITaskService
    {
        Task<User> CreateTask(User account, string header, string category, string priority);
        Task<User> UpdateTask(User account);
    }
}
