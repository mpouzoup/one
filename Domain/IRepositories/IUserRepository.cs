using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IRepositories;

public interface IUserRepository : IUnitOfWork
{
    Task<User?> GetUserById(int userId);
    Task<User?> GetUserByEmail(string email);
    Task<List<User>> GetAll();  
}
