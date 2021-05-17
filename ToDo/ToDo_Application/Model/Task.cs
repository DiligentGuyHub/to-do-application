using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDo_Application.Model
{
    public class Task
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int UserID { get; set; }
        public string Header { get; set; }
        public string Category { get; set; }
        public TaskPriority Priority { get; set; }
        public string Body { get; set; }
        public string[] Subtasks { get; set; }
        public DateTime Deadline { get; set; }
        public bool Completed { get; set; }

        // images
        // files
        public Task()
        {

        }
        
    }

    public enum TaskPriority
    { 
        Urgent = 1,
        High = 2,
        Medium = 3,
        Low = 4
    }

}
