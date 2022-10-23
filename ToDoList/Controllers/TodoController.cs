using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoRepository repo;

        public TodoController(ITodoRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var todos = repo.GetTodos();
            return View(todos);
        }

        public IActionResult ViewTodo(int id)
        {
            var todo = repo.GetTodo(id);
            return View(todo);
        }
        
        public IActionResult InsertTodoToDatabase(Todo todo)
        {
            repo.InsertTodo(todo);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTodoFromDatabase(Todo todo)
        {
            repo.DeleteTodo(todo);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateTodo(int id)
        {
            Todo todo = repo.GetTodo(id);   
            if (todo == null)
            {
                return View("TodoNotFound");
            }
            return View(todo);
        }

        public IActionResult UpdateTodoToDatabase(Todo todo)
        {
            repo.UpdateTodo(todo);

            return RedirectToAction("Index");
        }

    }
}
