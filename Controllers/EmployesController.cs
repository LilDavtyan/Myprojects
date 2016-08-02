using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Les8.Models;

namespace Les8.Controllers
{
    public class EmployesController : Controller
    {
        // GET: Employes

        public ActionResult EmployeeList(int Depid)
        {
            EmployeeContext emp = new EmployeeContext();
            List<Employee> emplist = emp.Employee.Where(em=>em.Depid==Depid).ToList();
            return View(emplist);
        }
        public ActionResult Details(int id)
        {
            EmployeeContext emp = new EmployeeContext();
            Employee result_emp = emp.Employee.Single(em => em.ID == id);
            return View(result_emp);
        }

            
    }
}