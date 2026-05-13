using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.IServices;

public interface IToDoService
{
    Task<List<ToDoList>> GetAllUserLists(int userId);
    Task<ToDoList> CreateList(ToDoList list);
    Task<ToDoList> UpdateList(ToDoList list);
    Task DeleteListById(int listId);

    Task<TaskItem> AddTaskToList(TaskItem task);
    Task<TaskItem> UpdateTask(TaskItem task);
    Task DeleteTaskById(int taskId);
}