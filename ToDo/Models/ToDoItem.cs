using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public bool Completed { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public Priority? Priority { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
