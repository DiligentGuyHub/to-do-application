using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Models;

namespace ToDo.Domain.Services
{
    public interface ITaskService : IDataService<Domain.Models.Task>
    {
        Task<User> CreateTask(
            User account,
            string header,
            string category,
            string priority, 
            DateTime deadline,
            string description = null,
            bool isCompleted = false,
            ICollection<AttachedImage> images = null,
            ICollection<AttachedFile> files = null,
            ICollection<SubTask> subTasks = null);
        Task<User> DeleteTask(User account, int id);
        Task<User> DuplicateTask(User account, int id);
    }
}
