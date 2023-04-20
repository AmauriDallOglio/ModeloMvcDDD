using Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Site
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<MeuContext>
    {

        public MeuContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
            .Build();

            var builder = new DbContextOptionsBuilder<MeuContext>()
                .UseSqlServer(config.GetConnectionString("ConexaoPadrao"),
            b => b.MigrationsAssembly("Infra"));

            return new MeuContext(builder.Options);
        }
    }
}
