using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IRepositories;

public interface INicknameRepository : IUnitOfWork
{
    Task<Nickname?> GetByIdAsync(int id);

    Task<IEnumerable<Nickname>> GetByUserIdAsync(int userId);
    Task AddAsync(Nickname nickname);
    void Update(Nickname nickname);
    void Delete(Nickname nickname);
}
