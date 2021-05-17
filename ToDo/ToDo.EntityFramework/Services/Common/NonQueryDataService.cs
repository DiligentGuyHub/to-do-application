using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Models;

namespace ToDo.EntityFramework.Services.Common
{
    public class NonQueryDataService<T> where T : DomainBase
    {
        private readonly ToDoDbContextFactory _contextFactory;

        public NonQueryDataService(ToDoDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task<T> Create(T entity)
        {
            using (ToDoDbContext context = _contextFactory.CreateDbContext())
            {
                var result = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();

                return result.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (ToDoDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((entity) => entity.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (ToDoDbContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;

                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
            }
        }
    }
}
