﻿using System.Data.SqlClient;

namespace NGL.UiTests
{
    class DatabaseManager
    {
        private const string ConnectionStringTemplate = "Data Source=.;Initial Catalog={0};Integrated Security=True;MultipleActiveResultSets=True;App=EntityFramework";
        private const string NGLDb = "NGL_FunctionalTests";

        public static string ConnectionString
        {
            get { return GetConnectionStringFor(NGLDb); }
        }

        static string GetConnectionStringFor(string databaseName)
        {
            return string.Format(ConnectionStringTemplate, databaseName);
        }

        public static void RefreshDatabase()
        {
            var query = string.Format(@"
IF db_id('{0}') IS NOT NULL
BEGIN
    ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; 
    DROP DATABASE {0};
END 
CREATE DATABASE {0};",
                NGLDb);

            using (var connection = new SqlConnection(GetConnectionStringFor("master")))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = query;
                command.ExecuteNonQuery();
            }
        }
    }
}
