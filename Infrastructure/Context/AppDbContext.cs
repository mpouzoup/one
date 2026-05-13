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
    public virtual DbSet<ToDoList> TodoLists { get; set; }
    public virtual DbSet<TaskItem> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
                  

        modelBuilder.Entity<Nickname>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(n => n.User)
                .WithMany(u => u.Nicknames)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(n => n.Company)
                .WithMany(u => u.Departments)
                .HasForeignKey(n => n.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(n => n.Company)
                .WithMany(u => u.Users)
                .HasForeignKey(n => n.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);            
            entity.HasIndex(u => u.Email)
            .IsUnique();
        });

        modelBuilder.Entity<UserRoles>()
        .HasKey(ur => new { ur.UserId, ur.RoleId }); 

        modelBuilder.Entity<UserRoles>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);

        modelBuilder.Entity<UserRoles>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);

        modelBuilder.Entity<ToDoList>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(t => t.User)
                .WithMany(u => u.TodoLists)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<TaskItem>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(ti => ti.ToDoList)
                .WithMany(t => t.Tasks)
                .HasForeignKey(ti => ti.ToDoListId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.Property(e => e.Description).IsRequired();
        });
    }



}

