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

namespace RunForFun.Business.RunForFunBO
{
    public class ContactBO
    {
        ForFunDbHelper helper = new ForFunDbHelper();
       
        public bool Delete(int id)
        {
            string cmdText = "Delete from Contact where Id=@id";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id",id)
            };

            return helper.ExecuteCommand(cmdText, CommandType.Text, parameters);
        }
        public Contact Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetList()
        {
            List<Contact> list = new List<Contact>();
            string cmdText = "Select * from Contact";

            var reader = helper.GetData(cmdText, CommandType.Text);
            while (reader.Read())
            {
                list.Add(new Contact
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    UserName = reader["UserName"].ToString(),
                    Email = reader["Email"].ToString(),
                    Message = reader["Message"].ToString(),
                    Result = reader["Result"].ToString()

                });
            }
            return list;
        }

        public bool Insert(Contact model)
        {
            string cmdText = "Insert into Contact (UserName,Email,Message,Result) values(@username,@email,@mes,@res)";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@username",model.UserName),
                new SqlParameter("@email",model.Email),
                new SqlParameter("@mes",model.Message),
                new SqlParameter("@res",model.Result)
            };

            return helper.ExecuteCommand(cmdText, CommandType.Text, parameters);
        }

        public bool SendProblem(Contact model)
        {
            bool result = false;
            var users = GetList();
            foreach (var user in users)
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("cerenprojects@gmail.com", "Gerund123.");
                MailMessage msg = new MailMessage("cerenprojects@gmail.com", "ceren199704@hotmail.com");
                msg.Subject = "Send Problem";
                msg.IsBodyHtml = true;
                msg.Body = $"<h4> Hello Admin,I am {model.UserName} and my mail adres is : {model.Email} I input a problem to your application,please check.</h4><br><h3>My problem : {model.Message} </h3><h1>I hope you can solve it.Have a good day! :) </h1>";
                client.Send(msg);
                result = true;
            }
            return result;
        }
        public bool Update(Contact model)
        {
            throw new NotImplementedException();
           
        }
        public bool Edit(Contact model)
        { 
            string cmdText = "Update Contact set Result=@res where Id=@id";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id",model.Id),
                new SqlParameter("@res",model.Result),
            };
            return helper.ExecuteCommand(cmdText, CommandType.Text, parameters);
        }
    }

}
