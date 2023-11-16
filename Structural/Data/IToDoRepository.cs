// TodoRepository.cs
using System;
using System.Collections.Generic;
using System.Linq;

public class TodoRepository : ITodoRepository
{
    private List<TodoItem> _todos = new List<TodoItem>();

    public IEnumerable<TodoItem> GetAll() => _todos;

    public TodoItem? GetById(int id) => _todos.FirstOrDefault(t => t.Id == id);

    public void Add(TodoItem item)
    {
        item.Id = _todos.Count + 1;
        _todos.Add(item);
    }

    public void Update(TodoItem item)
    {
        var existingTodo = _todos.FirstOrDefault(t => t.Id == item.Id);
        if (existingTodo != null)
        {
            existingTodo.Title = item.Title;
            existingTodo.IsCompleted = item.IsCompleted;
        }
        else
        {
            throw new InvalidOperationException($"Todo item with ID {item.Id} not found.");
        }
    }

    public void Delete(int id)
    {
        var todoToRemove = _todos.FirstOrDefault(t => t.Id == id);
        if (todoToRemove != null)
        {
            _todos.Remove(todoToRemove);
        }
        else
        {
            throw new InvalidOperationException($"Todo item with ID {id} not found.");
        }
    }
}
