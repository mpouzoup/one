using Domain.IRepositories;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;

public class NicknameRepository : UnitOfWork, INicknameRepository
{
    public NicknameRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Nickname?> GetByIdAsync(int id)
    {
        return await _dbContext.Nicknames
            .FirstOrDefaultAsync(n => n.Id == id);
    }

    public async Task<IEnumerable<Nickname>> GetByUserIdAsync(int userId)
    {
        return await _dbContext.Nicknames
            .Where(n => n.UserId == userId)
            .ToListAsync();
    }

    public async Task AddAsync(Nickname nickname)
    {
        await _dbContext.Nicknames.AddAsync(nickname);
    }

    public void Update(Nickname nickname)
    {
        _dbContext.Nicknames.Update(nickname);
    }

    public void Delete(Nickname nickname)
    {
        _dbContext.Nicknames.Remove(nickname);
    }
}