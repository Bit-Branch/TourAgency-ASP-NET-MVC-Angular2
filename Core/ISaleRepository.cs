using System.Collections.Generic;
using System.Threading.Tasks;
using TourAgency.Core.Models;

namespace TourAgency.Core
{
    public interface ISaleRepository
    {
         Task<Sale> GetSale(int id);
        Task<List<Sale>> GetSales();

        void Add(Sale sale);

        void Remove(Sale sale);

       
    }
}