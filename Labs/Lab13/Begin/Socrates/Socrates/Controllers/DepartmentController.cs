﻿using Socrates.DataAccess;
using Socrates.Models;
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

        public ActionResult Edit(int id)
        {
            Department dept = context.GetAllDepartments().SingleOrDefault(d => d.Id == id);
            if (dept == null) return HttpNotFound();
            return View(dept);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var dept = new Department();
            if (TryUpdateModel(dept, collection)) {
                context.MarkAsModified(dept);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}