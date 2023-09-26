using Grocery.Soti.Project.DAL.Interfaces;
using Grocery.Soti.Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Soti.Project.DAL
{
    public class RegisterUserService : IUser
    {
        private SqlConnection _connection = null;
        private SqlCommand _command = null;
        //private SqlDataReader _reader = null;

        public async Task<bool> RegisterUser(User user)
        {
            using (_connection = new SqlConnection(SqlConnectionString.GetConnectionString))
            {
                using (_command = new SqlCommand("usp_registerUser", _connection))
                {
                    _command.CommandType = CommandType.StoredProcedure;
                    if (_connection.State != ConnectionState.Open)
                    {
                        _connection.Open();
                    }
                    _command.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = user.FirstName;
                    _command.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = user.LastName;
                    _command.Parameters.Add("@Gender", SqlDbType.Char, 6).Value = user.Gender;
                    _command.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = user.DateOfBirth;
                    _command.Parameters.Add("@MobileNumber", SqlDbType.Char, 10).Value = user.MobileNumber;
                    _command.Parameters.Add("@EmailId", SqlDbType.VarChar, 150).Value = user.EmailId;
                    _command.Parameters.Add("@Password", SqlDbType.VarChar, 150).Value = user.Password;
                    //int registerUserResponse = await _command.ExecuteNonQuery();
                    ; int registerUserResponse = await _command.ExecuteNonQueryAsync();
                    return registerUserResponse > 0;

                }
            }
        }

        public async Task<string> LoginUser(User user)
        {
            using (_connection = new SqlConnection(SqlConnectionString.GetConnectionString))
            {
                using (_command = new SqlCommand("usp_loginUser", _connection))
                {
                    _command.CommandType = CommandType.StoredProcedure;
                    if (_connection.State != ConnectionState.Open)
                    {
                        _connection.Open();
                    }

                    // Define and add the output parameter
                    SqlParameter outputParameter = new SqlParameter("@EncryptedPassword", SqlDbType.VarChar, 150);
                    outputParameter.Direction = ParameterDirection.Output;
                    _command.Parameters.Add("@EmailId", SqlDbType.VarChar, 150).Value = user.EmailId;
                    _command.Parameters.Add(outputParameter);

                    await _command.ExecuteNonQueryAsync();

                    // Retrieve the password from the output parameter
                    var password = _command.Parameters["@EncryptedPassword"].Value as string;

                    return password;
                }
            }
        }

        //static void Main(string[] args)
        //{
        //    RegisterUserService rs = new RegisterUserService();
        //    bool ans = rs.RegisterUser("Rk","kh","Male", new DateTime(2000, 02, 02), "8949451439","k2@gmail.com");
        //    Console.WriteLine(ans);
        //}
    }
}