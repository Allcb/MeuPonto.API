using MeuPonto.Domain.Core.Events;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections;

namespace MeuPonto.Infra.Data.Context
{
    public class EventStoreSQLContext : DbContext
    {
        #region Propriedades Publicas

        public DbSet<StoredEvent> StoredEvent { get; set; }

        #endregion Propriedades Publicas

        #region Metodos Protegidos

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string _environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfigurationRoot _configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                                          .AddJsonFile(path: "appsettings.json",
                                                                                       optional: true)
                                                                          .AddJsonFile(path: $"appsettings.{_environment}.json",
                                                                                       optional: true,
                                                                                       reloadOnChange: true)
                                                                          .AddEnvironmentVariables()
                                                                          .Build();

            if (_environment.Equals("Test"))
                optionsBuilder.UseInMemoryDatabase(databaseName: "EventStore");
            else
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString(nameof(EventStoreSQLContext)));
        }

        #endregion Metodos Protegidos

        #region Metodos Privados

        private string GetConnectionStringFromEnvironment()
        {
            IDictionary _variaveisAmbiente = Environment.GetEnvironmentVariables();

            Console.WriteLine(Environment.GetEnvironmentVariables());

            SqlConnectionStringBuilder _connectionStringBuilder = new SqlConnectionStringBuilder();

            _connectionStringBuilder.DataSource = _variaveisAmbiente["SERVIDOR"]?.ToString();
            _connectionStringBuilder.InitialCatalog = _variaveisAmbiente["NOME_BANCO"]?.ToString();
            _connectionStringBuilder.IntegratedSecurity = true;
            _connectionStringBuilder.PersistSecurityInfo = false;
            _connectionStringBuilder.UserID = _variaveisAmbiente["LOGIN"]?.ToString();
            _connectionStringBuilder.Password = _variaveisAmbiente["SENHA"]?.ToString();
            _connectionStringBuilder.MultipleActiveResultSets = false;
            _connectionStringBuilder.Encrypt = false;
            _connectionStringBuilder.TrustServerCertificate = false;
            _connectionStringBuilder.Add(keyword: "Trusted_Connection", value: false);
            _connectionStringBuilder.Pooling = true;
            _connectionStringBuilder.MaxPoolSize = 5000;

            return _connectionStringBuilder.ConnectionString;
        }

        #endregion Metodos Privados
    }
}