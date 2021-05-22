using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Models;
using ToDo.Domain.Services;
using ToDo.EntityFramework.Services.Common;

namespace ToDo.EntityFramework.Services
{
    public class AccountDataService : GenericDataService<User>, IAccountService
    {
        public AccountDataService(ToDoDbContextFactory contextFactory, ToDoDbContext toDoDbContext) : base(contextFactory, toDoDbContext)
        {
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
