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
    public class GenericDataService<T> : IDataService<T> where T : DomainBase
    {
        private readonly ToDoDbContextFactory _contextFactory;
        private readonly NonQueryDataService<T> _nonQueryDataService;
        public GenericDataService(ToDoDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
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

        public async Task<IEnumerable<T>> GetAll()
        {
            using (ToDoDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();
                return entities;
            }
        }

    }
}
