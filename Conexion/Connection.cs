using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Conexion
{
    public class Connection
    {
        public static string Conexion()
        {
            string conection = System.Configuration.ConfigurationManager.ConnectionStrings["FLunaConnection"].ConnectionString;
            return conection;
        }
    }
}
