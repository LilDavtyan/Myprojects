using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Les8.Models
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }

        public System.Data.Entity.DbSet<Les8.Models.Student> Students { get; set; }
    }
}