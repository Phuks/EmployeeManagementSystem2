using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem2.Models;

namespace EmployeeManagementSystem2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTypeDetail> EmployeeTypeDetails { get; set; }
        public DbSet<EmployeeWageRate> EmployeeWageRates { get; set; }
        public DbSet<EmployeeHistory> EmployeeHistories { get; set; }
        public DbSet<Inquiry> Inquiries { get; set; }
        public DbSet<EmployeeManagementSystem2.Models.EmployeeTypeDetailVM> EmployeeTypeDetailVM { get; set; }
        public DbSet<EmployeeManagementSystem2.Models.EmployeeWageRateVM> EmployeeWageRateVM { get; set; }
    }
}
