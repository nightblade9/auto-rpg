using AutoRpg.DatabaseMediator;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AutoRpg.ServiceExtensions
{
    public abstract class AbstractService
    {
        public IDatabaseMediator CreateDatabaseMediator()
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            var connectionString = configuration["ConnectionStrings:DefaultConnection"];

            var connectionStrings = new ConnectionStrings() { DefaultConnection = connectionString };
            return new DatabaseMediator.DatabaseMediator(connectionStrings);
        }
    }
}
