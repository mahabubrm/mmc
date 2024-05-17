using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mwc.Core.Models.Common
{
    public class AppDbConnection
    {
        public static string ServerName { get; set; }
        public static string DataBaseName { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static string DatabaseProvider { get; set; }

        public static string ConnectionString { get; set; }
    }
}
