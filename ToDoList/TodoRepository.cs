using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Context;
using ToDoList.Models;

namespace ToDoList
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DapperContext _context;
        public TodoRepository(DapperContext context)
        {
            _context = context; 
        }

        public void DeleteTodo(Todo todo)
        {
            var query = "DELETE FROM todos WHERE Id = @id;";
            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, new { id = todo.Id});
            }
        }

        public Todo GetTodo(int id)
        {
            var query = "SELECT * FROM Todos WHERE Id = @id;";
            using (var connection = _context.CreateConnection())
            {
                var todo = connection.QuerySingle<Todo>(query, new {id = id });
                return todo;
            }
        }

        public IEnumerable<Todo> GetTodos()
        {
            var query = "SELECT * FROM todos;";
            using (var connection = _context.CreateConnection())
            {
                var todos = connection.Query<Todo>(query);
                return todos;
            }
        }

        public void InsertTodo(Todo todoToInsert)
        {
            var query = "INSERT INTO todos (Task) VALUES (@task);";
            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, new { task = todoToInsert.Task});
            }
        }

        public void UpdateTodo(Todo todo)
        {
            var query = "UPDATE todos SET Task = @task WHERE Id = @id;";
            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, new { task = todo.Task, id = todo.Id});
            }
        }
    }
}
