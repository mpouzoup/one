using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Utilities;

public static class PasswordEncryption
{
    
    public static string HashPassword(string plainTextPassword)
    {
        return BCrypt.Net.BCrypt.EnhancedHashPassword(plainTextPassword);
    }
  
    public static bool VerifyPassword(string plainTextPassword, string hashedHashFromDb)
    {
        return BCrypt.Net.BCrypt.EnhancedVerify(plainTextPassword, hashedHashFromDb);
    }
}
