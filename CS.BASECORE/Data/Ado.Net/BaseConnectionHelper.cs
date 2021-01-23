using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.BASECORE.Data.Ado.Net
{
    public class BaseConnectionHelper
    {
        public string ConnectionString { get; set; }

        public bool ExecuteCommand(string cmdText, CommandType type = CommandType.Text, List<SqlParameter> parameters = null)
        {
            bool result = false;
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(cmdText, con))
                    {
                        cmd.CommandType = type;
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters.ToArray());
                        }
                        con.Open();
                        result = cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return result;
        }
        public SqlDataReader GetData(string cmdText, CommandType type = CommandType.Text, List<SqlParameter> parameters = null)
        {
            SqlDataReader reader = null;
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand(cmdText, con);
                cmd.CommandType = type;
                if (parameters != null)
                {
                    cmd.Parameters.Add(parameters.ToArray());
                }
                con.Open();
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {
                throw;
            }
            return reader;
        }
    }

}
