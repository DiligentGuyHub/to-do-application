using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.EntityFramework
{
    public class ToDoDbContextFactory
    {
        private readonly string _connectionString;

        public ToDoDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ToDoDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<ToDoDbContext>();
            options.UseSqlServer(_connectionString);
            return new ToDoDbContext(options.Options);
        }
    }
}
