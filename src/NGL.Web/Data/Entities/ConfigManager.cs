using System;
using System.Configuration;
using Microsoft.WindowsAzure;

namespace NGL.Web.Data.Entities
{
    public class ConfigManager
    {
        public const string StudentBlobContainer = "student";

        public static string EdmxConnectionString
        {
            get { return GetEdmxConnectionString(ConnectionString); }
        }

        public static string GetEdmxConnectionString(string connectionString)
        {
            var edmxConnectionString =
                string.Format(
                    "metadata=res://*/Data.Entities.NglDbContext.csdl|res://*/Data.Entities.NglDbContext.ssdl|res://*/Data.Entities.NglDbContext.msl;provider=System.Data.SqlClient;provider connection string='{0}'",
                    connectionString);
            return edmxConnectionString;
        }

        public static string ConnectionString
        {
            get
            {
                var injectedConnectionString = Environment.GetEnvironmentVariable("ConnectionString");
                return injectedConnectionString ?? ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            }
        }

        public static string BlobConnectionString
        {
            get
            {
                var blobConnectionString = Environment.GetEnvironmentVariable("BlobConnectionString");
                return  blobConnectionString ?? CloudConfigurationManager.GetSetting("BlobConnectionString");
            }
        }
    }
}