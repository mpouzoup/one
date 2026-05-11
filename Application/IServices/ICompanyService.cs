using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces;

public interface ICompanyService
{
    public Task<Company> Save(Company company);
    public Task<Company> Update(Company company);
    public Task DeleteById(int companyId);
    public Task<Company?> GetCompany(Company company);
    public Task<Company?> GetCompanyById(int companyId);
    public Task<List<Company>> GetAllCompanies();
    public Task<List<User>> GetEmployeesByCompanyId(int companyId);
}
