using Application.IServices;
using Domain.IRepositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services;

public class ToDoService : IToDoService
{
    private readonly IToDoRepository _toDoRepository;

    public ToDoService(IToDoRepository toDoRepository)
    {
        _toDoRepository = toDoRepository;
    }

    public async Task<List<ToDoList>> GetAllUserLists(int userId)
    {
        return await _toDoRepository.GetUserLists(userId);
    }

    public async Task<ToDoList> CreateList(ToDoList list)
    {
        try
        {
            if (string.IsNullOrEmpty(list.Title))
                throw new Exception("Title is required.");

            _toDoRepository.Add(list);
            await _toDoRepository.SaveChangesAsync();
            return list;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<ToDoList> UpdateList(ToDoList list)
    {
        try
        {
            var existingList = await _toDoRepository.GetListById(list.Id);
            if (existingList == null)
                throw new Exception("To-Do List not found");

            existingList.Title = list.Title;

            _toDoRepository.UpdateList(existingList);

            await _toDoRepository.SaveChangesAsync();

            return existingList;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task DeleteListById(int listId)
    {
        try
        {
            var list = await _toDoRepository.GetListById(listId);
            if (list == null)
                throw new Exception("List not found");

            _toDoRepository.Remove(list);
            await _toDoRepository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<TaskItem> AddTaskToList(TaskItem task)
    {
        try
        {
            _toDoRepository.Add(task);
            await _toDoRepository.SaveChangesAsync();
            return task;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<TaskItem> UpdateTask(TaskItem task)
    {
        try
        {
            _toDoRepository.UpdateTask(task);
            await _toDoRepository.SaveChangesAsync();
            return task;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task DeleteTaskById(int taskId)
    {
        try
        {
            var task = await _toDoRepository.GetTaskById(taskId);

            if (task == null)
                throw new Exception("Task not found");

            _toDoRepository.Remove(task);
            await _toDoRepository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}