using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;
using ToDo.ViewModels;

namespace ToDo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IToDoRepository _todoRepository;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IToDoRepository toDoItemRepository, IWebHostEnvironment enviroment, ILogger<HomeController> logger)
        {
            _todoRepository = toDoItemRepository;
            _environment = enviroment;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var viewModel = new ToDoViewModel
            {
                ToDoItems = _todoRepository.GetToDoItems()
            };
            return View(viewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ToDoCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var todo = new ToDoItem
                {
                    Name = model.Name,
                    Description = model.Description,
                    Priority = model.Priority,
                    DueDate = model.DueDate
                };

                _todoRepository.AddToDo(todo);

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            var todo = _todoRepository.GetToDoItem(id);
            var model = new ToDoEditViewModel
            {
                Id = todo.Id,
                Completed = todo.Completed,
                Name = todo.Name,
                Description = todo.Description,
                Priority = (Priority)todo.Priority,
                DueDate = (DateTime)todo.DueDate
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ToDoEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var todo = _todoRepository.GetToDoItem(model.Id);
                todo.Completed = todo.Completed;
                todo.Name = todo.Name;
                todo.Description = todo.Description;
                todo.Priority = todo.Priority;
                todo.DueDate = todo.DueDate;

                _todoRepository.UpdateToDo(todo);

                return RedirectToAction("Index");
            }
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
