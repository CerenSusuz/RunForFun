using CS.BASECORE.Data.Ado.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunForFun.Datacore.RunForFunData
{
    public class ForFunDbHelper : BaseConnectionHelper
    {
        public ForFunDbHelper()
        {
            ConnectionString = "Data Source=CEREN\\SQLEXPRESS; Initial Catalog=ForFunDb; Integrated Security=true;";
        }

    }
}
