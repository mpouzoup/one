using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IRepositories;

public interface ICompanyRepository: IUnitOfWork
{
    Task<Company?> GetCompanyById(int companyId);
    Task<List<Company>> GetCompanies();
    Task<List<User>> GetEmployeesByCompanyId(int companyId);
}
