using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Encore.Infra.Data.Context
{
    public class ApplicationContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationContext(DbContextOptions<ApplicationContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();

            var assembly = typeof(ApplicationContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string? connectionString = _configuration.GetConnectionString("DefaultConnection");
                
                if (connectionString == null)
                    throw new ApplicationException("Não foi possível fazer a conexão como o banco. ConnectionString não encontrada.");
                
                optionsBuilder.UseSqlServer(connectionString, o =>
                {
                    o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    o.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                });
            }
        }

        #region IDisposable

        private bool _disposed;

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (Database.CurrentTransaction != null)
                    Database.CurrentTransaction.Dispose();

                _disposed = true;
            }

            base.Dispose();
        }
        #endregion
    }
}