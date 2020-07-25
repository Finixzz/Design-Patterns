using FactoryDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryDemo.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeType> EmployeeTypes { get; set; }

        protected  override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<EmployeeType>().HasData(
                    new EmployeeType() { Id=1,Name="Permanent"},
                    new EmployeeType() { Id=2,Name="Contract"}
                );
        }
    }
}
