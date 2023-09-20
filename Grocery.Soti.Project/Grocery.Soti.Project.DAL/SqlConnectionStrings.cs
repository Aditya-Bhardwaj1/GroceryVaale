using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Soti.Project.DAL
{
<<<<<<< HEAD
    public  class SqlConnectionStrings
    {
        public static string GetConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["FullStackCon"].ConnectionString;
            }
=======
    public class SqlConnectionStrings
    {
        public static string GetConnectionString 
        { 
            get 
            {
                return ConfigurationManager.ConnectionStrings["NorthwinCon"].ConnectionString;
            } 
>>>>>>> origin/master
        }
    }
}
