using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Models;
using ToDo.Domain.Services;

namespace ToDo.EntityFramework.Services.Common
{
    public class TaskDataService : ITaskService
    {
        private readonly IDataService<User> _accountService;

        public TaskDataService(IDataService<User> accountService)
        {
            _accountService = accountService;
        }

        public async Task<User> CreateTask(User account, string header, string category, string priority)
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
                    Description = "",
                    Deadline = DateTime.Now,
                    IsCompleted = false,
                    Images = null,
                    Files = null,
                    Subtasks = null
                };
            

            account.Tasks.Add(task);
            }
            await _accountService.Update(account.Id, account);
            return account;
        }
        public async Task<User> UpdateTask(User account)
        {
            await _accountService.Update(account.Id, account);
            return account;
        }

        //private readonly ToDoDbContextFactory _contextFactory;
        //private readonly NonQueryDataService<ToDo.Domain.Models.Task> _nonQueryDataService;
        //public TaskDataService(ToDoDbContextFactory contextFactory)
        //{
        //    _contextFactory = contextFactory;
        //    _nonQueryDataService = new NonQueryDataService<ToDo.Domain.Models.Task>(contextFactory);
        //}

        //public async Task<ToDo.Domain.Models.Task> Create(ToDo.Domain.Models.Task entity)
        //{
        //    return await _nonQueryDataService.Create(entity);
        //}

        //public async Task<bool> Delete(int id)
        //{
        //    return await _nonQueryDataService.Delete(id);
        //}
        //public async Task<ToDo.Domain.Models.Task> Update(int id, ToDo.Domain.Models.Task entity)
        //{
        //    return await _nonQueryDataService.Update(id, entity);
        //}

        //public async Task<ToDo.Domain.Models.Task> Get(int id)
        //{
        //    using (ToDoDbContext context = _contextFactory.CreateDbContext())
        //    {
        //        // include tasks
        //        ToDo.Domain.Models.Task entity = await context.Tasks
        //            .Include(a => a.Account)
        //            .Include(a => a.Images)
        //            .Include(a => a.Files)
        //            .Include(a => a.Category)
        //            .Include(a => a.Subtasks)
        //            .FirstOrDefaultAsync((entity) => entity.Id == id);
        //        return entity;
        //    }
        //}

        //public async Task<IEnumerable<ToDo.Domain.Models.Task>> GetAll()
        //{
        //    using (ToDoDbContext context = _contextFactory.CreateDbContext())
        //    {
        //        IEnumerable<ToDo.Domain.Models.Task> entities = await context.Tasks
        //            .Include(a => a.Account)
        //            .Include(a => a.Images)
        //            .Include(a => a.Files)
        //            .Include(a => a.Category)
        //            .Include(a => a.Subtasks)
        //            .ToListAsync();
        //        return entities;
        //    }
        //}

    }
}
