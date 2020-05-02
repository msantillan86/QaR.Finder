using Microsoft.EntityFrameworkCore;
using QaR.Finder.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace QaR.Finder.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Item> Items { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
