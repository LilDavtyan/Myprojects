using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Les8.Models
{
    [Table("Department")]
    public class Department
    {
        public int id { get; set; }
        public string department { get; set; }
        //List<Employee> Employees { get; set; }
    }
}