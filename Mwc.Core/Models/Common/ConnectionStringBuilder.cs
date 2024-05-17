using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mwc.Core.Models.Common
{
    public class ConnectionStringBuilder
    {
        public static string DbConnectionString()
        {
            var newConnStringBuilder = new SqlConnectionStringBuilder
            {
                UserID = ConfigurationManager.AppSettings["Username"].ToString(),
                Password = ConfigurationManager.AppSettings["Password"].ToString(),
                InitialCatalog = ConfigurationManager.AppSettings["DatabaseName"].ToString(),
                DataSource = ConfigurationManager.AppSettings["DataSource"].ToString()
            };

            var entityConnectionBuilder = new EntityConnectionStringBuilder
            {
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = newConnStringBuilder.ToString(),
                Metadata = @"res://*//Models.IntelliERPDBModel.csdl|
                            res://*//Models.IntelliERPDBModel.ssdl|
                            res://*//Models.IntelliERPDBModel.msl"
            };

            return entityConnectionBuilder.ToString();
        }
    }
}
