using System.Collections.Generic;
using System.Threading.Tasks;
using TourAgency.Core.Models;

namespace TourAgency.Core
{
    public interface ITourRepository
    {
        Task<Tour> GetTour(int id, bool includeRelated = true);

        void Add(Tour tour);

        void Remove(Tour tour);

        Task<List<Tour>> GetTours();  
    }
}