        using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Domain.Models
{
    public class Task : DomainBase
    {
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User Account { get; set; }
        public string Header { get; set; }
        public string Category { get; set; }
        public string Priority { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsCompleted { get; set; }
        public ICollection<AttachedImage> Images { get; set; }
        public ICollection<AttachedFile> Files { get; set; }
        public ICollection<SubTask> Subtasks { get; set; }
    }
}
