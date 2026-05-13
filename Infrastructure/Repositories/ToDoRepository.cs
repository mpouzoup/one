using Domain.IRepositories;
using Domain.Models;
using Infrastructure.Context;
using Infrastructure.Migrations;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastructure.Repositories;

public class ToDoRepository : UnitOfWork, IToDoRepository
{
    private readonly AppDbContext _dbContext;

    public ToDoRepository(AppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ToDoList>> GetUserLists(int userId)
    {
        return await _dbContext.TodoLists
                               .Where(x => x.UserId == userId)
                               .Include(x => x.Tasks)
                               .AsNoTracking()
                               .ToListAsync();
    }

    public async Task<ToDoList?> GetListById(int listId)
    {
        return await _dbContext.TodoLists
                               .Include(x => x.Tasks)
                               .FirstOrDefaultAsync(x => x.Id == listId);
    }

    public async Task<List<TaskItem>> GetTasksByListId(int listId)
    {
        var list = await _dbContext.TodoLists
                                   .Include(l => l.Tasks)
                                   .FirstOrDefaultAsync(l => l.Id == listId);

        return list?.Tasks.ToList() ?? new List<TaskItem>();
    }

    public void UpdateList(ToDoList list)
    {
        _dbContext.TodoLists.Update(list);
    }

    public void UpdateTask(TaskItem task)
    {
        _dbContext.Tasks.Update(task);
    }

    public async Task<TaskItem?> GetTaskById(int taskId)
    {
        return await _dbContext.Tasks
                               .FirstOrDefaultAsync(x => x.Id == taskId);
    }
}
