using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.Models
{
    public interface IToDoRepository
    {
        ToDoItem GetToDoItem(int id);
        IEnumerable<ToDoItem> GetToDoItems();
        ToDoItem AddToDo(ToDoItem todo);
        ToDoItem UpdateToDo(ToDoItem todo);
        ToDoItem DeleteToDo(int id);
    }
}
