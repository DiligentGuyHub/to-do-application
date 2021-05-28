using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Models;

namespace ToDo.EntityFramework
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Domain.Models.User> Users { get; set; }
        public DbSet<Domain.Models.Task> Tasks { get; set; }
        //public DbSet<Domain.Models.Category> Categories { get; set; }
        public DbSet<Domain.Models.AttachedImage> Images { get; set; }
        public DbSet<Domain.Models.AttachedFile> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Models.Task>()
                .HasMany(item => item.Images)
                .WithOne(item => item.Task)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
