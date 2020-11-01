using AutenticationDemo.Models;
using Dapper;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AutenticationDemo.Providers
{
    public class OAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.Run(() => context.Validated());
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            using (var conn = new SqlConnection("data source=(localdb)\\mssqllocaldb;initial catalog=ZooDatabase;integrated security=true"))
            {
                string username = context.UserName;
                string passwordHash = ComputeHash(context.Password); // computing hash of password

                // searching the user in the database
                var user = conn.QuerySingleOrDefault<User>("SELECT * FROM Users WHERE Username = @username AND PasswordHash = @passwordHash"
                    , new { username, passwordHash });

                // if the user is found, claims are added
                if (user != null)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
                    identity.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString()));
                    await Task.Run(() => context.Validated(identity));
                }
                else
                {
                    context.SetError("Wrong Crendentials", "Provided username and password is incorrect");
                }

            }
        }

        private string ComputeHash(string input)
        {
            using (var sha = SHA512.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}