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
    public class MovieBO : IMainBO<Movie>
    {
        ForFunDbHelper helper = new ForFunDbHelper();
        public bool Delete(int id)
        {
            string cmdText = "Delete from Movies where Id=@id";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id",id)
            };

            return helper.ExecuteCommand(cmdText, CommandType.Text, parameters);
        }

        public Movie Get(int id)
        {
            Movie user = new Movie();
            string cmdText = "Select * from Movies where Id=@id";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id",id)
            };

            var reader = helper.GetData(cmdText, CommandType.Text, parameters);
            while (reader.Read())
            {
                user.Id = Convert.ToInt32(reader[nameof(user.Id)]);
                user.Name = reader[nameof(user.Name)].ToString();
                user.Starring = reader[nameof(user.Starring)].ToString();
                user.Director = reader[nameof(user.Director)].ToString();
                user.Country = reader[nameof(user.Country)].ToString();
                user.Imdb = reader[nameof(user.Imdb)].ToString();
                user.ReleaseDate = Convert.ToDateTime(reader[nameof(user.ReleaseDate)]);
                user.RunningTime = reader[nameof(user.RunningTime)].ToString();
                user.Type = reader[nameof(user.Type)].ToString();
                user.VideoSite = reader[nameof(user.VideoSite)].ToString();
                user.Trailer = reader[nameof(user.Trailer)].ToString();
                user.Picture = reader[nameof(user.Picture)].ToString();

            }
            return user;
        }

        public List<Movie> GetList()
        {
            List<Movie> list = new List<Movie>();
            string cmdText = "Select * from Movies";

            var reader = helper.GetData(cmdText, CommandType.Text);
            while (reader.Read())
            {
                list.Add(new Movie
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Starring = reader["Starring"].ToString(),
                    Director = reader["Director"].ToString(),
                    Country = reader["Country"].ToString(),
                    Imdb = reader["Imdb"].ToString(),
                    ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"]),
                    RunningTime = reader["RunningTime"].ToString(),
                    Type = reader["Type"].ToString(),
                    VideoSite = reader["VideoSite"].ToString(),
                    Trailer = reader["Trailer"].ToString(),
                    Picture = reader["Picture"].ToString()

                });
            }
            return list;
        }

        public bool Insert(Movie model)
        {

            string cmdText = "Insert into Movies (Name,Starring,Director,Country,Imdb,ReleaseDate,RunningTime,Type,VideoSite,Trailer,Picture) values(@name,@star,@drc,@coun,@imdb,@rdate,@rtime,@type,@vSite,@tra,@pic)";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@name",model.Name),
                new SqlParameter("@star",model.Starring),
                new SqlParameter("@drc",model.Director),
                new SqlParameter("@coun",model.Country),
                new SqlParameter("@imdb",model.Imdb),
                new SqlParameter("@rdate",model.ReleaseDate),
                new SqlParameter("@rtime",model.RunningTime),
                new SqlParameter("@type",model.Type),
                new SqlParameter("@vSite",model.VideoSite),
                new SqlParameter("@tra",model.Trailer),
                new SqlParameter("@pic",model.Picture),

            };

            return helper.ExecuteCommand(cmdText, CommandType.Text, parameters);
        }

        public bool Update(Movie model)
        {
            string cmdText = "Update Movies set VideoSite=@vSite,Trailer=@tra,Picture=@pic where Id=@id";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id",model.Id),
                new SqlParameter("@vSite",model.VideoSite),
                new SqlParameter("@tra",model.Trailer),
                new SqlParameter("@pic",model.Picture)
            };
            return helper.ExecuteCommand(cmdText, CommandType.Text, parameters);
        }
    }
}

