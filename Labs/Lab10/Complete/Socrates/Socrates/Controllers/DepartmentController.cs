using Socrates.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Socrates.Controllers
{
    public class DepartmentController : SocratesController
    {
        //
        // GET: /Department/
        public ActionResult Index()
        {
            var departments = context.GetAllDepartments().OrderBy(d => d.Name).ToList();

            return View(departments);
        }
    }
}