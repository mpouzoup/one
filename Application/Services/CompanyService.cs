using Application.Interfaces;
using Domain.IRepositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace Application.Services;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;

    public object NavigationManager { get; private set; }

    public CompanyService(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task<Company> Save(Company company)
    {
        _companyRepository.Add(company);
        await _companyRepository.SaveChangesAsync();
        return company;
    }


    public async Task<Company> Update(Company company)
    {
        try
        {
            var existingCompany = await _companyRepository.GetCompanyById(company.Id);
            if (existingCompany == null)
                throw new Exception("Exception");
            existingCompany.UpdateValues(company);
            await _companyRepository.SaveChangesAsync();

            return existingCompany;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<List<Company>> GetAllCompanies()
    {
        return await _companyRepository.GetCompanies();
    }

    public async Task<Company?> GetCompanyById(int companyId)

    {
        try
        {
            var existingCompany = await _companyRepository.GetCompanyById(companyId);
            if (existingCompany == null)
                throw new Exception("Exception");
            return existingCompany;
        }
        catch (Exception ex)

        {

            throw;

        }

    }

    public async Task DeleteById(int companyId)
    {
        try
        {
            var existingCompany = await _companyRepository.GetCompanyById(companyId);
            if (existingCompany == null)
                throw new Exception("Exception");

            _companyRepository.Remove(existingCompany);
            await _companyRepository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<Company?> GetCompany(Company company)
    {
        if (company == null || company.Id == 0)
            return null;

        return await _companyRepository.GetCompanyById(company.Id);
    }
    
    public async Task<List<User>> GetEmployeesByCompanyId(int companyId)
    {
        return await _companyRepository.GetEmployeesByCompanyId(companyId);
    }

}
