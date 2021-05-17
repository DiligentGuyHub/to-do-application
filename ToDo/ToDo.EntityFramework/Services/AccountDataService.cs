using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Models;
using ToDo.Domain.Services;
using ToDo.EntityFramework.Services.Common;

namespace ToDo.EntityFramework.Services
{
    public class AccountDataService : IAccountService
    {
        private readonly ToDoDbContextFactory _contextFactory;
        private readonly NonQueryDataService<User> _nonQueryDataService;

        public AccountDataService(ToDoDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<User>(contextFactory);
        }
        // излишне
        public async Task<User> Create(User entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }
        public async Task<User> Update(int id, User entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }

        public async Task<User> Get(int id)
        {
            using (ToDoDbContext context = _contextFactory.CreateDbContext())
            {
                // include tasks
                User entity = await context.Users
                    .Include(a => a.Tasks)
                    .FirstOrDefaultAsync((entity) => entity.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            using (ToDoDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<User> entities = await context.Users
                    .Include(a => a.Tasks)
                    .ToListAsync();
                return entities;
            }
        }

        public async Task<User> GetByUsername(string username)
        {
            using (ToDoDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Users
                    .Include(a => a.Tasks)
                    .FirstOrDefaultAsync(a => a.Username == username);
            }
        }

        public async Task<User> GetByEmail(string email)
        {
            using (ToDoDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Users
                    .Include(a => a.Tasks)
                    .FirstOrDefaultAsync(a => a.Email == email);
            }
        }
    }
}
