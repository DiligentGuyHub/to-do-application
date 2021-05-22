using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Models;
using ToDo.Domain.Services;

namespace ToDo.EntityFramework.Services.Common
{
    public class TaskDataService : GenericDataService<Domain.Models.Task>, ITaskService
    {
        public TaskDataService(ToDoDbContextFactory contextFactory, ToDoDbContext toDoDbContext) : base(contextFactory, toDoDbContext)
        {
        }

        public async Task<User> CreateTask(
            User account,
            string header,
            string category,
            string priority,
            DateTime deadline,
            string description = null,
            bool isCompleted = false,
            ICollection<AttachedImage> images = null,
            ICollection<AttachedFile> files = null,
            ICollection<SubTask> subTasks = null
            )
        {
            if (!string.IsNullOrEmpty(header) &&
                !string.IsNullOrEmpty(category) &&
                !string.IsNullOrEmpty(priority))
            {
                Domain.Models.Task task = new Domain.Models.Task()
                {
                    Account = account,
                    Header = header,
                    Category = category,
                    Priority = priority,
                    Description = description,
                    Deadline = deadline,
                    IsCompleted = isCompleted,
                    Images = images,
                    Files = files,
                    Subtasks = subTasks
                };


                account.Tasks.Add(task);
            }
            return account;
        }

        public async Task<User> DeleteTask(User account, int id)
        {
            Domain.Models.Task Task = account.Tasks
                .Where(item => item.Id == id)
                .FirstOrDefault();
            account.Tasks.Remove(Task);
            await Delete(id);
            return account;
        }
        public async Task<User> DuplicateTask(User account, int id)
        {
            Domain.Models.Task Task = account.Tasks
                .Where(item => item.Id == id)
                .FirstOrDefault();
            await CreateTask(
                Task.Account,
                Task.Header,
                Task.Category,
                Task.Priority,
                DateTime.Now,
                Task.Description,
                Task.IsCompleted,
                Task.Images,
                Task.Files,
                Task.Subtasks
            );

            return account;
        }
    }
}
