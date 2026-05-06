
using Application.Dtos.Auth;
using Application.Interfaces;
using Application.IServices;
using Application.Utilities;
using Domain.IRepositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace Application.Services;


public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ICompanyService _companyService;
    private readonly INicknameService _nicknameService;
    

    public UserService(IUserRepository userRepository,ICompanyService companyService, INicknameService nicknameService)
    {
        _userRepository = userRepository;        
        _companyService = companyService;
        _nicknameService = nicknameService;
    }

    public Task<User> DuplicateUser(User user, User user2)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUser(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<User> Save(User user)
    {
        try
        {
            if (!VatValidator.ValidateVatNumber(user.AFM))
            {
                throw new Exception("The AFM provided is invalid.");
            }
            User newUser = new User
            {
                Name = user.Name,
                LastName = user.LastName,
                AFM = user.AFM,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Company = user.Company,
                CompanyId = user.CompanyId
            };
            _userRepository.Add(newUser);
            await _userRepository.SaveChangesAsync();
            if (user.Nicknames != null)
            {
                foreach (var item in user.Nicknames)
                {
                    item.UserId = newUser.Id;
                    await _nicknameService.Save(item);
                }
            }

            return newUser;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<User> Update(User user)
    {
        try
        {
            var existingUser = await _userRepository.GetUserById(user.Id);
            if (existingUser == null)
                throw new Exception("User not found");

            if (!VatValidator.ValidateVatNumber(user.AFM))
            {
                throw new Exception("The AFM provided is invalid.");
            }

            existingUser.UpdateValues(user);
            await _userRepository.SaveChangesAsync();

            return existingUser;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _userRepository.GetAll();
    }

    public async Task<User?> GetUserByID(int userId)
    {
        try
        {
            var existingUser = await _userRepository.GetUserById(userId);
            if (existingUser == null)
                throw new Exception("Exception");          

            return existingUser;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task DeleteById(int userId)
    {
        try
        {
            var existingUser = await _userRepository.GetUserById(userId);
            if (existingUser == null)
                throw new Exception("Exception");

            _userRepository.Remove(existingUser);
            await _userRepository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<User> SignUp(SignUpDto signUpDto)
    {
        try
        {
            
            var user = await _userRepository.GetUserByEmail(signUpDto.Email);
            if (user != null)
                throw new Exception("A user with this email already exists.");

            if (!VatValidator.ValidateVatNumber(signUpDto.AFM))
                throw new Exception("The AFM provided is invalid.");
            var newUser = new User()
            {
                Name = signUpDto.Name,
                LastName = signUpDto.LastName,
                Email = signUpDto.Email,
                PhoneNumber = signUpDto.PhoneNumber,
                AFM = signUpDto.AFM,
                Password = PasswordEncryption.HashPassword(signUpDto.Password),                
            };
            _userRepository.Add(newUser);
            await _userRepository.SaveChangesAsync();

            var newRole = new UserRoles()
            {
                UserId = newUser.Id,
                RoleId = 3
            };

            _userRepository.Add(newRole);
            await _userRepository.SaveChangesAsync();

            return newUser;
        }
        catch(Exception ex)
        {            
            throw;
        }
    }

    public async Task<User?> Login(LoginModel loginDto)
    {
        var user = await _userRepository.GetUserByEmail(loginDto.Email);

        if (user == null)
        {
            return null;
        }

        bool isPasswordValid = PasswordEncryption.VerifyPassword(loginDto.Password, user.Password);

        if (!isPasswordValid)
        {
            return null;
        }

        return user;
    }

    public async Task<User> AdminRegisterUser(SignUpDto dto, int roleId)
    {
        var existingUser = await _userRepository.GetUserByEmail(dto.Email);
        if (existingUser != null) throw new Exception("User already exists");

        var newUser = new User
        {
            Name = dto.Name,
            LastName = dto.LastName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            AFM = dto.AFM,
            Password = PasswordEncryption.HashPassword(dto.Password),
            UserRoles = new List<UserRoles>
        {
            new UserRoles { RoleId = roleId }
        }
        };

        _userRepository.Add(newUser);
        await _userRepository.SaveChangesAsync();
        return newUser;
    }
}
