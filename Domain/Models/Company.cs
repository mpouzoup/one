using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models;

public class Company
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public List<User> Users { get; set; } = new List<User>();
    public List<Department> Departments { get; set; } = new List<Department>();

    public Company UpdateValues(Company company)
    {
        this.Id = company.Id;
        this.Name = company.Name;
        this.Address = company.Address;
        return this;
    }

}
