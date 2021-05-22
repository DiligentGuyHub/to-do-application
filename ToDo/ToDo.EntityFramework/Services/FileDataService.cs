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
    public class FileDataService : GenericDataService<AttachedFile>, IFileService
    {
        public FileDataService(ToDoDbContextFactory contextFactory, ToDoDbContext toDoDbContext) : base(contextFactory, toDoDbContext)
        {
        }
    }
}
