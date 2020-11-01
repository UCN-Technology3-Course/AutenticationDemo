using AuthenticationDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AutenticationDemo.Controllers
{
    public class EmployeeController : ApiController
    {
        private static readonly Employee localEmployee = new Employee
        {
            Id = 1,
            Name = "Jens Hansen",
            Salary = 20000
        };


        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(localEmployee);
        }

        [HttpPut]
        public IHttpActionResult StoreSecret(double salary)
        {
            localEmployee.Salary = salary;

            return Ok(localEmployee);
        }
    }
}
