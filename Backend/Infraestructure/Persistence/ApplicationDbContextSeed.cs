using QaR.Finder.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace QaR.Finder.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            if (!context.Items.Any())
            {
                context.Items.Add(new Item { Id = Guid.NewGuid().ToString(), Text = "Item 1", Description = "This is an item description." });
                context.Items.Add(new Item { Id = Guid.NewGuid().ToString(), Text = "Item 2", Description = "This is an item description." });
                context.Items.Add(new Item { Id = Guid.NewGuid().ToString(), Text = "Item 3", Description = "This is an item description." });

                await context.SaveChangesAsync();
            }
        }
    }
}
