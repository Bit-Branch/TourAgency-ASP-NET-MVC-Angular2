using System.Threading.Tasks;
using TourAgency.Core;

namespace TourAgency.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TourAgencyDbContext context;

        public UnitOfWork(TourAgencyDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}