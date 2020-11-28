using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{
    public class ToDoItem
    {
        [Key]
        public int Id { get; set; }
        public bool Completed { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public Priority? Priority { get; set; }

        [Display(Name = "Due Date")]
        public DateTime? DueDate { get; set; }
    }
}
