using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Domain.Models
{
    public class SubTask : DomainBase
    {
        public int? TaskId { get; set; }
        [ForeignKey("TaskId")]
        public Task Task { get; set; }
        public string Header { get; set; }
    }
}
