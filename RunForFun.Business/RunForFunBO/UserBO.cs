using CS.BASECORE.Data.Ado.Net;
using RunForFun.Datacore.RunForFunData;
using RunForFun.Model.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RunForFun.Business.RunForFunBO
{
    public class UserBO : IMainBO<ApplicationUser>
    {
        ForFunDbHelper helper = new ForFunDbHelper();
        public bool Delete(int id)
        {
            string cmdText = "Delete from ApplicationUsers where Id=@id";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id",id)
            };

            return helper.ExecuteCommand(cmdText, CommandType.Text, parameters);
        }

        public ApplicationUser Get(int id)
        {
            ApplicationUser user = new ApplicationUser();
            string cmdText = "Select * from ApplicationUsers where Id=@id";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id",id)
            };

            var reader = helper.GetData(cmdText, CommandType.Text, parameters);
            while (reader.Read())
            {
                user.Id = Convert.ToInt32(reader[nameof(user.Id)]);
                user.UserName = reader[nameof(user.UserName)].ToString();
                user.Password = reader[nameof(user.Password)].ToString();
                user.Email = reader[nameof(user.Email)].ToString();
                user.FullName = reader[nameof(user.FullName)].ToString();
                user.BirthDate = Convert.ToDateTime(reader[nameof(user.BirthDate)]);
                user.Picture = reader[nameof(user.Picture)].ToString();
            }
            return user;
        }

        public List<ApplicationUser> GetList()
        {
            List<ApplicationUser> list = new List<ApplicationUser>();
            string cmdText = "Select * from ApplicationUsers";

            var reader = helper.GetData(cmdText, CommandType.Text);
            while (reader.Read())
            {
                list.Add(new ApplicationUser
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    UserName = reader["UserName"].ToString(),
                    Password = reader["Password"].ToString(),
                    Email = reader["Email"].ToString(),
                    FullName = reader["FullName"].ToString(),
                    BirthDate = Convert.ToDateTime(reader["BirthDate"]),
                    Picture = reader["Picture"].ToString()
                });
            }
            return list;
        }

        public bool Insert(ApplicationUser model)
        {
            string cmdText = "Insert into ApplicationUsers (UserName,Password,Email,FullName,BirthDate,Picture) values(@username,@password,@email,@fullname,@bDate,@pic)";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@username",model.UserName),
                new SqlParameter("@password",model.Password),
                new SqlParameter("@email",model.Email),
                new SqlParameter("@fullname",model.FullName),
                new SqlParameter("@bDate",model.BirthDate),
                new SqlParameter("@pic",model.Picture)
            };

            return helper.ExecuteCommand(cmdText, CommandType.Text, parameters);
        }

        public bool Update(ApplicationUser model)
        {
            string cmdText = "Update ApplicationUsers set UserName=@username,Password=@password,Email=@email,FullName=@fullname,BirthDate=@bDate,Picture=@pic where Id=@id";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id",model.Id),
                new SqlParameter("@username",model.UserName),
                new SqlParameter("@password",model.Password),
                new SqlParameter("@email",model.Email),
                new SqlParameter("@fullname",model.FullName),
                new SqlParameter("@bDate",model.BirthDate),
                new SqlParameter("@pic",model.Picture)
            };
            return helper.ExecuteCommand(cmdText, CommandType.Text, parameters);
        }
        public bool Login(string userName, string password)
        {
            bool result = false;
            try
            {
                var users = GetList();
                foreach (var user in users)
                {
                    if (user.UserName.ToLower() == userName.ToLower() && user.Password.ToLower() == password.ToLower())
                    {
                        result = true;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Login Error.");
                result = false;
            }
            return result;
        }
        public bool ForgotPassword(string eMail)
        {
            bool result = false;
            var users = GetList();
            foreach (var user in users)
            {
                if (user.Email == eMail)
                {
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("cerenprojects@gmail.com", "Gerund123.");
                    MailMessage msg = new MailMessage("cerenprojects@gmail.com", eMail);
                    msg.Subject = "Forgot password";
                    msg.IsBodyHtml = true;
                    msg.Body = $"<h4> Hello {user.UserName}, It is your Password : {user.Password} </h4><br><h1>Have a good day! :) </h1>";
                    client.Send(msg);
                    result = true;
                }
            }

            return result;
        }

       
    }
}
