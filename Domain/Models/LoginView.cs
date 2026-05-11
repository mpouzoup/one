using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models;

public class LoginView
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string? UserName { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide Password ")]
    public string? Password {  get; set; }

}
