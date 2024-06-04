using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFAdditiveApp;



public partial class HrsDbContext : DbContext
{
    public HrsDbContext()
    {
    }

    public HrsDbContext(DbContextOptions<HrsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<EmployeesFull> EmployeesFull { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HrsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        //optionsBuilder.UseLoggerFactory(ConsoleLoggerFactory);
        optionsBuilder.UseLoggerFactory(MyLoggerFactory);
    }

    //public static readonly ILoggerFactory ConsoleLoggerFactory = LoggerFactory.Create(builder =>
    //{
    //    builder.AddConsole();
    //});

    public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name
                                              && level == LogLevel.Information)
               .AddProvider(new MyLoggerProvider());
    });




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().ToTable("Employees");

        modelBuilder.Entity<Employee>()
                    .ToTable("EmployeesTemporal", t => t.IsTemporal());

        modelBuilder.Entity<Project>()
                    .ToTable("ProjectsTemporal", t => t.IsTemporal());


        modelBuilder.Entity<EmployeesFull>(ef =>
        {
            ef.HasNoKey();
            ef.ToView("View_EmployeesFull");
        });



        //OnModelCreatingPartial(modelBuilder);
    }

    private void StandartOnModeCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Company>(entity =>
        //{
        //    entity.HasIndex(e => e.CountryId, "IX_Companies_CountryId");

        //    entity.HasOne(d => d.Country).WithMany(p => p.Companies).HasForeignKey(d => d.CountryId);
        //});

        //modelBuilder.Entity<Employee>(entity =>
        //{
        //    entity.HasIndex(e => e.CompanyId, "IX_Employees_CompanyId");

        //    entity.HasIndex(e => e.PositionId, "IX_Employees_PositionId");

        //    entity.Property(e => e.Discriminator).HasMaxLength(13);
        //    entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");

        //    entity.HasOne(d => d.Company).WithMany(p => p.Employees).HasForeignKey(d => d.CompanyId);

        //    entity.HasOne(d => d.Position).WithMany(p => p.Employees).HasForeignKey(d => d.PositionId);

        //    entity.HasMany(d => d.Projects).WithMany(p => p.Employees)
        //        .UsingEntity<Dictionary<string, object>>(
        //            "EmployeeProject",
        //            r => r.HasOne<Project>().WithMany().HasForeignKey("ProjectsId"),
        //            l => l.HasOne<Employee>().WithMany().HasForeignKey("EmployeesId"),
        //            j =>
        //            {
        //                j.HasKey("EmployeesId", "ProjectsId");
        //                j.ToTable("EmployeeProject");
        //                j.HasIndex(new[] { "ProjectsId" }, "IX_EmployeeProject_ProjectsId");
        //            });
        //});

        //modelBuilder.Entity<Position>(entity =>
        //{
        //    entity.Property(e => e.Activity).HasDefaultValue(true);
        //});

        //modelBuilder.Entity<Employee>()
        //            .Property(e => e.Salary)
        //            .IsConcurrencyToken();

        ////modelBuilder.Entity<Company>()
        ////            .Property(c => c.Timestamp)
        ////            .IsRowVersion();
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
