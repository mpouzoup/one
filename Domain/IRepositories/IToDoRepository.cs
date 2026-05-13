using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IRepositories;

public interface IToDoRepository : IUnitOfWork
{
    Task<List<ToDoList>> GetUserLists(int userId);
    Task<ToDoList?> GetListById(int listId);
    Task<List<TaskItem>> GetTasksByListId(int listId);

    Task<TaskItem?> GetTaskById(int taskId);

    void UpdateList(ToDoList list);
    void UpdateTask(TaskItem task);
}