using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using QaR.Finder.Application.Common.Interfaces;
using QaR.Finder.Domain.Common;
using QaR.Finder.Domain.Entities;
using System.Data;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace QaR.Finder.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private IDbContextTransaction _currentTransaction;
        private readonly IDateTime _dateTime;

        public ApplicationDbContext(DbContextOptions options, ICurrentUserService currentUserService, IDateTime dateTime) : base(options)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public DbSet<Item> Items { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<CamposAuditoria>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreadoPor = _currentUserService.UserId;
                        entry.Entity.CreadoFecha = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ActualizadoPor = _currentUserService.UserId;
                        entry.Entity.ActualizadoFecha = _dateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public async Task BeginTransactionAsync()
        {
            if (_currentTransaction != null)
            {
                return;
            }

            _currentTransaction = await base.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted).ConfigureAwait(false);
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync().ConfigureAwait(false);

                _currentTransaction?.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
