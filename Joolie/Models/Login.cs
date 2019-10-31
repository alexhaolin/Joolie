using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Joolie.Models
{
    public class Login
    {
        // ************** UserName *******************
        [Required(ErrorMessage = "Please enter your Username.")]
        [Display(Name = "Username: ")]
        public string UserName { get; set; }

        // ************** Password *******************
        [Required(ErrorMessage = "Please enter your Password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password: ")]
        public string Password { get; set; }


        // ************** Remember Me  *******************
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

        public bool IsValid(string _username, string _password)
        {
            System.Diagnostics.Debug.WriteLine("User: " + _username);

            String connectionString = ConfigurationManager.AppSettings["UserLoginSQLConnectionString"];
            SqlConnection connecntion = new SqlConnection(connectionString);
            string query = @"SELECT [UserName] FROM [dbo].[User]" +
                                      @"WHERE [UserName] = @u AND [UserPassword] = @p";
            SqlCommand cmd = new SqlCommand(query, connecntion);
            cmd.Parameters.Add("@u", SqlDbType.VarChar);
            cmd.Parameters["@u"].Value = _username;
            cmd.Parameters.Add("@p", SqlDbType.VarChar);
            cmd.Parameters["@p"].Value = _password;

            connecntion.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            System.Diagnostics.Debug.WriteLine("Credential Valid? " + reader.HasRows);

            if (reader.HasRows)
            {
                reader.Close();
                cmd.Dispose();
                return true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Error: Can't login.");
                reader.Close();
                return false;
            }
        }
    }
}