using Microsoft.SqlServer.Dac;
using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.Entity.Core.EntityClient;

namespace Bootstrap
{
    public class DataBase
    {
        public void Run(string connectionString)
        {
            var providerConnectionString = new EntityConnectionStringBuilder(connectionString).ProviderConnectionString;
            DbConfiguration.SetConfiguration(new PocDbConfiguration());
            var context = new DbContext(providerConnectionString);
            context.Database.Initialize(true);
            using (var connection = new SqlConnection(providerConnectionString))
            {
                connection.Open();
                var connectionStringBuilder = new SqlConnectionStringBuilder(providerConnectionString) { AttachDBFilename = String.Empty };
                var dacServices = new DacServices(connectionStringBuilder.ToString());
#if DEBUG
                const string dacpacFile = @"..\..\..\Database\bin\Debug\Database.dacpac";
#else
                const string dacpacFile = @"..\..\..\Database\bin\Release\Database.dacpac";
#endif
                var package = DacPackage.Load(dacpacFile);

                dacServices.Deploy(package, connection.Database, true);
                connection.Close();
            }
        }
    }
}
