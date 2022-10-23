using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList
{
    public interface ITodoRepository
    {
        public IEnumerable<Todo> GetTodos();
        public Todo GetTodo(int id);
        public void UpdateTodo(Todo todo);
        public void InsertTodo(Todo todoToInsert);
        public void DeleteTodo(Todo todo);
    }
}
