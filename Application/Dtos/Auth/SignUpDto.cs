using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Dtos.Auth;

public class SignUpDto
{   
    public string Name { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string AFM { get; set; }
    public string Password { get; set; }
    public string RepeatPassword { get; set; }
    [Required(ErrorMessage = "Please select a role")]
    public int SelectedRoleId { get; set; }

}
