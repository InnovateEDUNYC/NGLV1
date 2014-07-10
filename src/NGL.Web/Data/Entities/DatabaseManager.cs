using System;
using System.Configuration;

namespace NGL.Web.Data.Entities
{
    public class DatabaseManager
    {
        public static string EdmxConnectionString
        {
            get
            {
            var edmxConnectionString =
                string.Format(
                    "metadata=res://*/Data.Entities.NglDbContext.csdl|res://*/Data.Entities.NglDbContext.ssdl|res://*/Data.Entities.NglDbContext.msl;provider=System.Data.SqlClient;provider connection string='{0}'",
                    ConnectionString);
            return edmxConnectionString;
            }
        }

        public static string ConnectionString
        {
            get
            {
                var injectedConnectionString = Environment.GetEnvironmentVariable("ConnectionString");
                return injectedConnectionString ?? ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            }
        }
    }
}