using Grocery.Soti.Project.DAL.Interfaces;
using Grocery.Soti.Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Security.Cryptography;

namespace Grocery.Soti.Project.DAL
{
    public class UserDetails : IAccount
    {
        public string getUserRole(string userEmail)
        {
            using (SqlConnection connection = new SqlConnection(SqlConnectionString.GetConnectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("Select * from Users", connection))
                {
                    using (DataSet ds = new DataSet())
                    {
                        adapter.Fill(ds, "Users");

                        User user1= ds.Tables[0].AsEnumerable()
                            .Select(u => new User
                            {
                                FirstName = u.Field<string>("FirstName"),
                                LastName = u.Field<string>("LastName"),
                                EmailId = u.Field<string>("EmailId"),
                                Password = u.Field<string>("Password"),
                                MobileNumber = u.Field<string>("MobileNumber"),
                                Roles = u.Field<string>("Roles")
                            })
                            .FirstOrDefault(x => x.EmailId == userEmail);
                        return user1.Roles;
                    }
                }
            }
        }

        public Task<User> ValidateUserAsync(string emailId, string password)
        {
            return Task.Run(() =>
            {
                using (SqlConnection connection = new SqlConnection(SqlConnectionString.GetConnectionString))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter("Select * from Users", connection))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            adapter.Fill(ds, "Users");

                            return ds.Tables[0].AsEnumerable()
                                .Select(u => new User
                                {
                                    FirstName = u.Field<string>("FirstName"),
                                    LastName = u.Field<string>("LastName"),
                                    EmailId = u.Field<string>("EmailId"),
                                    Password = u.Field<string>("Password"),
                                    MobileNumber = u.Field<string>("MobileNumber"),
                                    Roles = u.Field<string>("Roles")
                                })
                                .FirstOrDefault(x => x.EmailId == emailId);
                        }
                    }
                }
            });
        }
    }
}