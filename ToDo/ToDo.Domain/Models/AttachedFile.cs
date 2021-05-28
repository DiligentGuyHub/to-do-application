using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Domain.Models
{
    public class AttachedFile : DomainBase
    {
        [ForeignKey("TaskId")]
        public int? TaskId { get; set; }
        public string Filename { get; set; }
        public byte[] File{ get; set; }

    }
}
