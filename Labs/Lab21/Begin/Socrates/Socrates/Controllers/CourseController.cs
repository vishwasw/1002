using Socrates.ViewModels;
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

        public ActionResult Edit(int id)
        {
            var ecvm = new CourseEditViewModel();
            ecvm.Course = context.GetAllCourses().SingleOrDefault(c => c.Id == id);
            if (ecvm.Course == null) return HttpNotFound();

            ecvm.Departments = context.GetAllDepartments().OrderBy(d => d.Name).ToList();
            return View(ecvm);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, int departmentId)
        {
            var course = context.GetAllCourses().SingleOrDefault(c => c.Id == id);

            bool isValid = TryUpdateModel(course, "Course", collection);
            if (isValid && (context.GetAllCourses().Count(c => c.Number == course.Number && c.Id != course.Id) > 0)) {
                isValid = false;
                ModelState.AddModelError("Course.Number", "Course number already in use");
            }
            if (isValid) {
                course.Department = context.GetAllDepartments().SingleOrDefault(d => d.Id == departmentId);
                context.SaveChanges();
                return RedirectToAction("Details", new { id = id });
            }
            // validation failed - repopulate ecvm
            var ecvm = new CourseEditViewModel();
            ecvm.Course = course;
            ecvm.Departments = context.GetAllDepartments().OrderBy(d => d.Name).ToList();
            return View(ecvm);
        }

        public ActionResult Search(string q)
        {
            var courses = context.GetAllCourses().Where(c => c.Title.Contains(q)).ToList();
            if (courses.Count() == 0) {
                return Content("<strong>No matching courses found</strong>");
            }
            return PartialView("_SearchResults", courses);
        }

        public ActionResult QuickSearch(string term)
        {
            var courseTitles = new List<string>();
            if (!String.IsNullOrEmpty(term)) {
                courseTitles = (from c in context.GetAllCourses()
                                where c.Title.Contains(term)
                                orderby c.Title
                                select c.Title).ToList();
            }
            return Json(courseTitles, JsonRequestBehavior.AllowGet);
        }
    }
}