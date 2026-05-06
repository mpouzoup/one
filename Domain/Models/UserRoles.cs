using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models;

public class UserRoles
{
    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;

    public int RoleId { get; set; }
    public virtual Role Role { get; set; } = null!;
}
