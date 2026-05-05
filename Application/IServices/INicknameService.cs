using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IServices;

public interface INicknameService
{
    Task<Nickname> Save(Nickname nickname);
    Task<Nickname> Update(Nickname nickname);
    Task DeleteById(int nicknameId);
    Task<Nickname?> GetNickname(Nickname nickname);
    Task<Nickname?> GetNicknameByID(int nicknameId);
    Task<List<Nickname>> GetNicknamesByUserId(int userId);
    Task<List<Nickname>> GetAllNicknames();
}
