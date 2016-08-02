using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Les8.Models
{
    public class StudentContext:DbContext
    {
        public DbSet<Student> Student { get; set; }

    }
}