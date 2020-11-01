using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InjectionDemo.Models
{
    public class UserAuthenticationRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public bool IsAuthenticated { get; set; }

        public string ExecutedSQL { get; set; }
    }
}