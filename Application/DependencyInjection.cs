using Application.Interfaces;
using Application.Services;
using Application.IServices;
using Domain.IRepositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICompanyService,CompanyService>();
        services.AddScoped<INicknameService,NicknameService>();

        return services;
    }
}
