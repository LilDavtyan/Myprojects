using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Les8.Models;

namespace Les8.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Deplist()
        {
            EmployeeContext emp = new EmployeeContext();
            List<Department> deplist = emp.Department.ToList();
            return View(deplist);
        }
    }
}