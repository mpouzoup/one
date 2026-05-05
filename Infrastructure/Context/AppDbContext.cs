using Domain.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Context;
 
public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Company> Companies { get; set; }
    public virtual DbSet<Nickname> Nicknames { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         
        modelBuilder.Entity<Company>()
            .HasMany(c => c.Users)
            .WithOne(x => x.Company)
            .HasForeignKey(p => p.CompanyId)                           
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Nickname>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(n => n.User)
                .WithMany(u => u.Nicknames)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

}

