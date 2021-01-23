using CS.BASECORE.Data.Ado.Net;
using RunForFun.Datacore.RunForFunData;
using RunForFun.Model.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunForFun.Business.RunForFunBO
{
    public class QuizBO : IMainBO<Quiz>
    {
        ForFunDbHelper helper = new ForFunDbHelper();

        public bool Delete(int id)
        {
            string cmdText = "Delete from Quizes where Id=@id";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id",id)
            };

            return helper.ExecuteCommand(cmdText, CommandType.Text, parameters);
        }

        public Quiz Get(int id)
        {
            Quiz user = new Quiz();
            string cmdText = "Select * from Quizes where Id=@id";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id",id)
            };

            var reader = helper.GetData(cmdText, CommandType.Text, parameters);
            while (reader.Read())
            {
                user.Id = Convert.ToInt32(reader[nameof(user.Id)]);
                user.Name = reader[nameof(user.Name)].ToString();
                user.Score = Convert.ToInt32(reader[nameof(user.Score)]);
            }
            return user;
        }

        public List<Quiz> GetList()
        {
                List<Quiz> list = new List<Quiz>();
                string cmdText = "Select * from Quizes";

                var reader = helper.GetData(cmdText, CommandType.Text);
                while (reader.Read())
                {
                list.Add(new Quiz
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Score = Convert.ToInt32(reader["Score"]),
                });
                }
                return list;
            }

        public bool Insert(Quiz model)
        {
            string cmdText = "Insert into Quizes (Name,Score) values (@username,@score)";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@username",model.Name),
                new SqlParameter("@score",model.Score),
                 
            };

            return helper.ExecuteCommand(cmdText, CommandType.Text, parameters);
        }

        public bool Update(Quiz model)
        {
            string cmdText = "Update Quizes set Score=@score where Id=@id";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id",model.Id),
                new SqlParameter("@score",model.Score),
            };
            return helper.ExecuteCommand(cmdText, CommandType.Text, parameters);
        }
    }
}
