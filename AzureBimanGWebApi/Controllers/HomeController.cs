using AzureBimanGWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AzureBimanGWebApi.Controllers
{
    public class HomeController : ApiController
    {
        private List<EmployeeDetails> _employees = new List<EmployeeDetails>
        {
            new EmployeeDetails{EmployeeName="Biman",Age= 35 , Address="Athpore" },
            new EmployeeDetails{EmployeeName="Priyanka",Age= 30,Address="PayraDanga" }
        };
       
        [HttpGet]
        public List<string> GetEmployees()
        {
            return _employees.Select(emp => emp.EmployeeName).ToList();

        }

        [HttpPost]
        public bool AddEmployees(string name , int age,string address)
        {
            _employees.Add(new EmployeeDetails { EmployeeName = name, Age = age, Address = address });
            return true;
        }

        [HttpDelete]
        public string DeleteEmployees(string name)

        {
            var item=_employees.FirstOrDefault(emp => emp.EmployeeName == name);
            _employees.Remove(item);
             return item.EmployeeName + "Deleted";


        }
        [HttpPut]
        public string UpdateEmpDetails(string Name, int age , string address)
        {
            var item = _employees.FirstOrDefault(emp => emp.EmployeeName == Name);
            item.Age = age;
            item.Address = address;
            return item.EmployeeName;
        }
    }
}
    