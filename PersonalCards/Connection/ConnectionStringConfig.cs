using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PersonalCards.Connection
{
    public class ConnectionStringConfig
    {
        public string ConnectionString { get; set; }

        public ConnectionStringConfig(string connectionStringName = "SaConnection",
            string environmentVariableConnectionString = "PCCDb_ConnectionString")
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<Program>()
                .Build();

            var server = "";
            var database = "";
            var userId = "";
            var password = "";

            config.Providers.Any(p => p.TryGet("PCCDb:Server", out server));
            config.Providers.Any(p => p.TryGet("PCCDb:Database", out database));
            config.Providers.Any(p => p.TryGet("PCCDb:UserId", out userId));
            config.Providers.Any(p => p.TryGet("PCCDb:Password", out password));

            ConnectionString = string.Format(config.GetConnectionString(connectionStringName) 
                ?? Environment.GetEnvironmentVariable(environmentVariableConnectionString),
                server,
                database,
                userId,
                password);
        }
    }
}
