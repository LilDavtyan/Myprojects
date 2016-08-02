using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Les8.Models;

namespace Les8.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult StudentList()
        {
            StudentContext studentlist = new StudentContext();
            List<Student> student = studentlist.Student.ToList();
            return View(student);
        }


        public ActionResult GetStudent(int id)
        {
            StudentContext stu = new StudentContext();
            Student studentlist = stu.Student.Single(st=>st.ID==id) ;
            return View(studentlist);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult CreateGet()
        {
            return View();
        }

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit_Get(int id)
        {
            StudentContext editstudent = new StudentContext();
            Student editstud = editstudent.Student.Single(st => st.ID == id);
            return View(editstud);
        }


        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post([Bind(Include="ID, FirstName, LastName")] Student stud)
        {
            StudentMonipulation st = new StudentMonipulation();
            stud.Keyword= st.Students.Single(sd => sd.ID == stud.ID).Keyword;
            
            if (ModelState.IsValid)
            {
                st.SaveStudent(stud);

                return RedirectToAction("StudentList");
            }
            return View(stud);
        }


        //[HttpPost]
        //[ActionName("Edit")]
        //public ActionResult Edit_Post(int id)
        //{
        //    StudentContext st = new StudentContext();
        //    Student editedstudent = st.Student.Single(sd => sd.ID == id);
        //    UpdateModel(editedstudent, new string[] { "FirstName", "LastName" });
        //    if (ModelState.IsValid)
        //    {
        //        StudentMonipulation savestudent = new StudentMonipulation();
        //        savestudent.SaveStudent(editedstudent);
                        
        //        return RedirectToAction("StudentList");
        //    }
        //    return View(editedstudent);
        //}
        
        [HttpPost]
        [ActionName("Create")]
        //public ActionResult Create(FormCollection formcollection)
        //{
        //   /* foreach(String key in formcollection)
        //    {
        //        Response.Write("Key="+key+" ");
        //        Response.Write(formcollection[key]);
        //        Response.Write("</br>");
        //    }
        //    return View();
        //    * */
        //    Student student = new Student();
        //    student.FirstName = formcollection["FirstName"];
        //    student.LastName = formcollection["LastName"];
        //    student.Keyword = formcollection["Keyword"];

        //    StudentMonipulation studentmonipulation = new StudentMonipulation();
        //    studentmonipulation.AddStudent(student);

        //    return RedirectToAction("StudentList");
        //}

        public ActionResult CreatePost()
        {

            if (ModelState.IsValid)
            {
                Student st = new Student();
                UpdateModel(st);
                StudentMonipulation studentmonipulation = new StudentMonipulation();
                studentmonipulation.AddStudent(st);

                return RedirectToAction("StudentList");
            }
            return RedirectToAction("Create");
        }

        public  ActionResult Delete(int id)
        {
            StudentMonipulation st = new StudentMonipulation();
            st.DeleteStudent(id);
            return RedirectToAction("StudentList");
        }
    }
}