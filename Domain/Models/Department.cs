using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CompanyId { get; set; }
    public virtual Company Company { get; set; }
}
