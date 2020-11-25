using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Data;

namespace ToDo.Models
{
    public class SqlToDoItemRepository : IToDoRepository
    {
        private ApplicationDbContext _context;

        public SqlToDoItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ToDoItem AddToDo(ToDoItem todo)
        {
            _context.ToDoItems.Add(todo);
            _context.SaveChanges();
            return todo;
        }

        public ToDoItem DeleteToDo(int id)
        {
            var todoItem = _context.ToDoItems.Find(id);
            if(todoItem != null)
            {
                _context.ToDoItems.Remove(todoItem);
                _context.SaveChanges();
            }
            return todoItem;
        }

        public ToDoItem GetToDoItem(int id)
        {
            return _context.ToDoItems.Find(id);
        }

        public IEnumerable<ToDoItem> GetToDoItems()
        {
            return _context.ToDoItems;
        }

        public ToDoItem UpdateToDo(ToDoItem todo)
        {
            var todoItem = _context.ToDoItems.Attach(todo);
            todoItem.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return todo;
        }
    }
}
