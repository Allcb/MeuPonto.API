using MeuPonto.Infra.Data.Context;
using MeuPonto.Infra.Data.Extensions;

namespace MeuPonto.Services.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build()
                                   .MigrateDatabase<MeuPontoContext>()
                                   .MigrateDatabase<EventStoreSQLContext>()
                                   .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseContentRoot(Directory.GetCurrentDirectory())
                               .UseIISIntegration()
                               .UseStartup<Startup>();
                 });
    }
}