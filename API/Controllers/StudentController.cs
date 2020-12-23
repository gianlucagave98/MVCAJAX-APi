using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DOMAIN;
using Service;

namespace API.Controllers
{
    public class StudentController : ApiController
    {

        public List<Student> GetStudents()
        {
            StudentService service = new StudentService();

            return service.Get();
        }

        public Student GetById(int id)
        {
            StudentService service = new StudentService();
            return service.GetById(id);
        }
        public void Insert(Student student)
        {
            StudentService service = new StudentService();
            service.Insert(student);
        }
        public void Update(Student student, int id)
        {
            StudentService service = new StudentService();
            service.Update(student, id);
        }
        public void Delete(int ID)
        {
            StudentService service = new StudentService();
            service.Delete(ID);
        }
    }
}
