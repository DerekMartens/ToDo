using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.ViewModels
{
    public class ToDoViewModel
    {
        public IEnumerable<ToDoItem> ToDoItems { get; set; }
    }
}
