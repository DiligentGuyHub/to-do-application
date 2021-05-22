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
    public class GenericDataService<T> : IDataService<T> where T : DomainBase
    {
        protected readonly ToDoDbContextFactory _contextFactory;
        protected readonly NonQueryDataService<T> _nonQueryDataService;
        protected readonly ToDoDbContext _toDoDbContext;
        public GenericDataService(ToDoDbContextFactory contextFactory, ToDoDbContext toDoDbContext)
        {
            _contextFactory = contextFactory;
            _toDoDbContext = toDoDbContext;
            _nonQueryDataService = new NonQueryDataService<T>(contextFactory);
        }

        public async Task<T> Create(T entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }
        public async Task<T> Update(int id, T entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }

        public async Task<T> Get(int id)
        {
            using (ToDoDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((entity) => entity.Id == id);
                return entity;
            }
        }
        public async Task<ICollection<T>> GetAll()
        {
            using (ToDoDbContext context = _contextFactory.CreateDbContext())
            {
                ICollection<T> entities = await context.Set<T>().ToListAsync();
                return entities;
            }
        }

        public async Task<IEnumerable<T>> GetJoin(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            //var query = Include(includeProperties);

            //return (await query.ToListAsync()).Where(predicate);
            using (ToDoDbContext context = _contextFactory.CreateDbContext())
            {
                return new List<T>(context.Set<T>().Where(predicate));
            }
        }

        private IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties)
        {
            using (ToDoDbContext context = _contextFactory.CreateDbContext())
            {
                IQueryable<T> query = context.Set<T>().AsNoTracking();

                return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }
        }

        public async Task<List<T>> GetJoin(Func<T, bool> func)
        {
            using (ToDoDbContext context = _contextFactory.CreateDbContext())
            {
                return new List<T>(context.Set<T>().Where(func));
            }
        }
    }
}
