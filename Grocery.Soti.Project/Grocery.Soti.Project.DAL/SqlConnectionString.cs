using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SOTI.DAL.DEMO.SEARCH
{
    public class SqlConnectionString
    {

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["FullStackCon"].ConnectionString;
        }
    }
}
