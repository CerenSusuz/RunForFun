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
    public class CommentBO : IMainBO<Comment>
    {
        ForFunDbHelper helper = new ForFunDbHelper();
        public bool Delete(int id)
        {
            string cmdText = "Delete from Comments where Id=@id";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id",id)
            };

            return helper.ExecuteCommand(cmdText, CommandType.Text, parameters);
        }

        public Comment Get(int id)
        {
            Comment user = new Comment();
            string cmdText = "Select * from Comments where Id=@id";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id",id)
            };

            var reader = helper.GetData(cmdText, CommandType.Text, parameters);
            while (reader.Read())
            {
                user.Id = Convert.ToInt32(reader[nameof(user.Id)]);
                user.Description = reader[nameof(user.Description)].ToString();
                user.Point = reader[nameof(user.Point)].ToString();
                user.UserName = reader[nameof(user.UserName)].ToString();
            }
            return user;
        }

        public List<Comment> GetList()
        {
            List<Comment> list = new List<Comment>();
            string cmdText = "Select * from Comments";

            var reader = helper.GetData(cmdText, CommandType.Text);
            while (reader.Read())
            {
                list.Add(new Comment
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Description = reader["Description"].ToString(),
                    Point = reader["Point"].ToString(),
                    UserName = reader["UserName"].ToString()
                });
            }
            return list;
        }

        public bool Insert(Comment model)
        {
            string cmdText = "Insert into Comments (Description,Point,UserName) values (@desc,@point,@Uname)";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@desc",model.Description),
                new SqlParameter("@point",model.Point),
                new SqlParameter("@uName",model.UserName)
            };
            return helper.ExecuteCommand(cmdText, CommandType.Text, parameters);
        }

        public bool Update(Comment model)
        {
            string cmdText = "Update Comments set Description=@desc,Point=@point,UserName=@UName where Id=@id";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id",model.Id),
                new SqlParameter("@desc",model.Description),
                new SqlParameter("@point",model.Point),
                new SqlParameter("@UName",model.UserName)
            };
            return helper.ExecuteCommand(cmdText, CommandType.Text, parameters);
        }
    }
}
