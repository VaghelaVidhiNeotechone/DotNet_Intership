using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBFirstApproach_CRUD.Models;

public partial class RegistrationCrudDbContext : DbContext
{
    public RegistrationCrudDbContext()
    {
    }

    public RegistrationCrudDbContext(DbContextOptions<RegistrationCrudDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserRegistration> UserRegistrations { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // The connection string is configured in Program.cs, so nothing is needed here.
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
