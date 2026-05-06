using Domain.IRepositories;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories;

public class UserRepository : UnitOfWork, IUserRepository
{
    private readonly AppDbContext _dbContext;
    public UserRepository(AppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
      
   
    public async Task<List<User>> GetAll()
    {
        return await _dbContext.Users
                               .Include(u => u.Nicknames)
                               .Include(u => u.UserRoles)
                               .ThenInclude(ur => ur.Role)
                               .AsNoTracking()
                               .ToListAsync();
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _dbContext.Users
                           .Include(u => u.UserRoles)
                           .ThenInclude(ur => ur.Role)
                           .FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<User?> GetUserById(int userId)
    {
        return await _dbContext.Users
                           .Include(u => u.Nicknames)
                           .FirstOrDefaultAsync(x => x.Id == userId);
    }
}
