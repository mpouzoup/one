using Application.Dtos.Auth;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces;

public interface IUserService
{
    public Task<User> Save(User user);
    public Task<User> Update(User user);
    public Task<User> SignUp(SignUpDto signUpDto);
    public Task<User?> Login(LoginModel loginDto);
    public Task DeleteById(int userId);
    public Task<User?> GetUser(User user);    
    public Task<User?> GetUserByID(int userId);
    public Task<List<User>> GetAllUsers();
    public Task<User> DuplicateUser(User user, User user2);  
    

}
