using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models;

public class Nickname : Entity
{
    public int Id { get; set; }
    public string Value { get; set; }
    public int UserId { get; set; }
    virtual public User User { get; set; }
}
