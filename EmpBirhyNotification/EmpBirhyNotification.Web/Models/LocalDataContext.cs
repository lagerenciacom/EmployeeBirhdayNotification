using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmpBirhyNotification.Web.Models
{
    public class LocalDataContext:DbContext
    {
        public LocalDataContext():base("DefaultConnection")
        {

        }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<Status> Status { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

    }
}