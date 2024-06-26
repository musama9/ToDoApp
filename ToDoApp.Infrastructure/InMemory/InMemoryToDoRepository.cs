﻿using ToDoApp.Core.Entities;
using ToDoApp.Core.Repositories;

namespace ToDoApp.Infrastructure.InMemory;

/// <inheritdoc/>
internal sealed class InMemoryToDoRepository : IToDoRepository
{
    private readonly List<ToDo> _toDoItems;

    public InMemoryToDoRepository()
    {
        _toDoItems = [];
    }

    /// <inheritdoc/>
    public Task<ToDo?> GetAsync(Guid id)
    {
        var toDo = _toDoItems.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(toDo);
    }

    /// <inheritdoc/>
    public Task<IEnumerable<ToDo>> ListAsync()
    {
        return Task.FromResult((IEnumerable<ToDo>)_toDoItems);
    }

    /// <inheritdoc/>
    public Task AddAsync(ToDo toDo)
    {
        _toDoItems.Add(toDo);
        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public Task UpdateAsync(ToDo toDo)
    {
        var existing = _toDoItems.FirstOrDefault(x => x.Id == toDo.Id);
        existing = toDo;
        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public Task DeleteAsync(ToDo toDo)
    {
        _toDoItems.Remove(toDo);
        return Task.CompletedTask;
    }
}
