using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DepartmentManager.Models;
using Vereyon.Web;

namespace DepartmentManager.Controllers
{
    public class DepartmentController : Controller
    {
        private ProjectDbContext projectDbContext;

        public DepartmentController()
        {
            projectDbContext = new ProjectDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            projectDbContext.Dispose();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                projectDbContext.Departments.Add(department);
                projectDbContext.SaveChanges();

                FlashMessage.Confirmation("Department saved successfully");
                return RedirectToAction("Create");
            }
            return View();
        }

        public ActionResult ViewDetails()
        {
            var departments = projectDbContext.Departments.ToList();
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "DepartmentName");
            return View();
        }

        public JsonResult GetAllStudents(int departmentId)
        {
            var strudents = projectDbContext.Students.Where(s => s.DepartmentId == departmentId).ToList();
            return Json(strudents);
        }

        public JsonResult IsCodeExist(string departmentcode)
        {
            var dpt = projectDbContext.Departments.ToList();
            if (dpt.Any(d=>d.DepartmentCode.ToLower() == departmentcode.ToLower()))
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);

        }


        public JsonResult GetStudentById(int id)
        {
            var student = projectDbContext.Students.FirstOrDefault(s => s.Id == id);
            return Json(student);
        }
    }
}