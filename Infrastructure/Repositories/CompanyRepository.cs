using Domain.IRepositories;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories;

public class CompanyRepository : UnitOfWork, ICompanyRepository
{
    public CompanyRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Company>> GetCompanies()
    {
        return await _dbContext.Companies.ToListAsync();
    }

    public async Task<Company?> GetCompanyById(int companyId)
    {
        return await _dbContext.Companies.FirstOrDefaultAsync(x => x.Id == companyId);
    }

    public async Task<List<User>> GetEmployeesByCompanyId(int companyId)
    {
        var company = await _dbContext.Companies
            .Include(c => c.Users)
            .FirstOrDefaultAsync(c => c.Id == companyId);

        return company?.Users ?? new List<User>();
    }
}
