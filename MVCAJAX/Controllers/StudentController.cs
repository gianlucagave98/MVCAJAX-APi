using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOMAIN;
using Service;
using MVCAJAX.Models;

namespace MVCAJAX.Controllers
{
    public class StudentController : Controller
    {
        private StudentService service = new StudentService();
        // GET: Student
        public ActionResult IndexRazor()
        {
            var model = (from c in service.Get()
                         select new StudentModel
                         {
                             ID = c.studentID,
                             Address = c.studentAddress,
                             Name = c.studentName,
                             Code = c.studentCode,
                             LastName = c.studentLastName
                         }).ToList();

            return View(model);
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetStudent(string id)
        {
            return Json(service.Get(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult getStudentById(int id)
        {
            return Json(service.GetById(id), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult createStudent(Student std)
        {
            service.Insert(std);
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
        [HttpPost]
        public JsonResult updateStudent(Student std, int id)
        {
            service.Update(std, id);
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult deleteStudent(int id)
        {
            service.Delete(id);
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
    }
}