using MVCAJAX.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MVCAJAX.Proxy
{
    public class StudentProxy
    {
        public async Task<ResponseProxy<StudentModel>> GetStudentsAsync()
        {
            var client = new HttpClient();
            var urlbase = "https://localhost:44383";
            client.BaseAddress = new Uri(urlbase);

            var url = string.Concat(urlbase, "/Api", "/Student", "/GetAllStudents");
            var response = client.GetAsync(url).Result;
            if(response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var students = JsonConvert.DeserializeObject<List<StudentModel>>(result);
                return new ResponseProxy<StudentModel>
                {
                    Exitoso=true,
                    Codigo = (int)HttpStatusCode.OK,
                    Mensaje="Exito",
                    listado=students
                };
            }
            else
            {
                return new ResponseProxy<StudentModel>
                {
                    Codigo= (int)response.StatusCode,
                    Mensaje="Error"
                };
            }
        }
        public async Task<ResponseProxy<StudentModel>> InsertAsync(StudentModel model)
        {
            var request = JsonConvert.SerializeObject(model);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            var urlbase = "https://localhost:44383";
            client.BaseAddress = new Uri(urlbase);
            var url = string.Concat(urlbase, "/Api", "/Student", "/InsertStudent");

            var response = client.PostAsync(url, content).Result;

            if(response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var exito = JsonConvert.DeserializeObject<bool>(result);
                return new ResponseProxy<StudentModel>
                {
                    Exitoso=exito,
                    Codigo=0,
                    Mensaje="Exito"
                };
            }
            else
            {
                return new ResponseProxy<StudentModel>
                {
                    Exitoso=false,
                    Codigo=(int)response.StatusCode,
                    Mensaje="Error"
                };
            }
        }
        public async Task<ResponseProxy<StudentModel>> UpdateAsync(StudentModel model)
        {
            var request = JsonConvert.SerializeObject(model);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            var urlbase = "https://localhost:44383";
            client.BaseAddress = new Uri(urlbase);
            var url = string.Concat(urlbase, "/Api", "/Student", "/UpdateStudent");

            var response = client.PutAsync(url, content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var exito = JsonConvert.DeserializeObject<bool>(result);
                return new ResponseProxy<StudentModel>
                {
                    Exitoso = exito,
                    Codigo = 0,
                    Mensaje = "Exito"
                };
            }
            else
            {
                return new ResponseProxy<StudentModel>
                {
                    Exitoso = false,
                    Codigo = (int)response.StatusCode,
                    Mensaje = "Error"
                };
            }
        }
    }
}