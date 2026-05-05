using Domain.IRepositories;
using Domain.Models;
using Application.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services;

public class NicknameService : INicknameService
{
    private readonly INicknameRepository _nicknameRepository;

    public NicknameService(INicknameRepository nicknameRepository)
    {
        _nicknameRepository = nicknameRepository;
    }

    public async Task<Nickname> Save(Nickname nickname)
    {
        await _nicknameRepository.AddAsync(nickname);
        await _nicknameRepository.SaveChangesAsync();
        return nickname;
    }

    public async Task<Nickname> Update(Nickname nickname)
    {
        try
        {
            var existingNickname = await _nicknameRepository.GetByIdAsync(nickname.Id);
            if (existingNickname == null)
                throw new Exception("Nickname not found");

            existingNickname.Value = nickname.Value;

            _nicknameRepository.Update(existingNickname);
            await _nicknameRepository.SaveChangesAsync();

            return existingNickname;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<Nickname>> GetAllNicknames()
    {
        var result = await _nicknameRepository.GetByUserIdAsync(0);
        return result.ToList();
    }

    public async Task<List<Nickname>> GetNicknamesByUserId(int userId)
    {
        var nicknames = await _nicknameRepository.GetByUserIdAsync(userId);
        return new List<Nickname>(nicknames);
    }

    public async Task<Nickname?> GetNicknameByID(int nicknameId)
    {
        try
        {
            var nickname = await _nicknameRepository.GetByIdAsync(nicknameId);
            if (nickname == null)
                throw new Exception("Nickname not found");

            return nickname;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task DeleteById(int nicknameId)
    {
        try
        {
            var existingNickname = await _nicknameRepository.GetByIdAsync(nicknameId);
            if (existingNickname == null)
                throw new Exception("Nickname not found");

            _nicknameRepository.Delete(existingNickname);
            await _nicknameRepository.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Nickname?> GetNickname(Nickname nickname)
    {
        if (nickname == null || nickname.Id == 0)
            return null;

        return await _nicknameRepository.GetByIdAsync(nickname.Id);
    }
}
