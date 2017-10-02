using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Socrates.Controllers
{
    public class CourseController : SocratesController
    {
        public ActionResult Index()
        {
            var departments = context.GetAllDepartments().OrderBy(d => d.Name).ToList();
            return View(departments);
        }

        public ActionResult Details(int id)
        {
            var course = context.GetAllCourses().SingleOrDefault(c => c.Id == id);
            if (course == null) return HttpNotFound();
            return View(course);
        }
    }
}