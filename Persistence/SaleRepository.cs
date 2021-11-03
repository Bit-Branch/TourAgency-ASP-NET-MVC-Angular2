using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TourAgency.Core;
using TourAgency.Core.Models;

namespace TourAgency.Persistence
{
    public class SaleRepository : ISaleRepository
    {
        private readonly TourAgencyDbContext context;

        public SaleRepository(TourAgencyDbContext context)
        {
            this.context = context;
        }

        public void Add(Sale sale)
        {
            context.Sales.Add(sale);
        }

        public async Task<List<Sale>> GetSales()
        {
            return await context.Sales.ToListAsync();
        }

        public void Remove(Sale sale)
        {
            context.Sales.Remove(sale);
        }
    }
}