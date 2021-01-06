using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MVCAJAX.Models;

namespace MVCAJAX.Controllers
{
    public class StudentController : Controller
    {
        Proxy.StudentProxy proxy = new Proxy.StudentProxy();
        public ActionResult IndexRazor()
        {
            var response = Task.Run(() => proxy.GetStudentsAsync());
            return View(response.Result.listado);
        }
        public JsonResult GetStudent(string id)
        {
            var response = Task.Run(() => proxy.GetStudentsAsync());
            return Json(response.Result.listado, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult createStudent(StudentModel std)
        {
            var response = Task.Run(() => proxy.InsertAsync(std));
            string message = response.Result.Mensaje;
            return Json(new { Message = message,JsonRequestBehavior.AllowGet});
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}