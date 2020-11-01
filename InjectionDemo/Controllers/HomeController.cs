using Dapper;
using InjectionDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InjectionDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserAuthenticationRequest dto)
        {
            using (var conn = new SqlConnection("data source=(localdb)\\mssqllocaldb;initial catalog=AuthenticationDemo;integrated security=true"))
            {
                string sql = $"SELECT * FROM UsernamePassword WHERE Username = '{dto.Username}' AND Password = '{dto.Password}'";

                var result = conn.Query(sql);

                dto.ExecutedSQL = sql;
                dto.IsAuthenticated = result.Any();
            }


            return View(dto);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}