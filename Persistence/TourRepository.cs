using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TourAgency.Core;
using TourAgency.Core.Models;

namespace TourAgency.Persistence
{
    public class TourRepository: ITourRepository
    {
      private readonly TourAgencyDbContext context;

      public TourRepository(TourAgencyDbContext context)
      {
        this.context = context;
      }

      public async Task<Tour> GetTour(int id)
      {
          return await context.Tours
            .Include(h => h.Hotel)
            .Include(v => v.Sales)
            .SingleOrDefaultAsync(v => v.Id == id);
      }

      public void Add(Tour tour) 
      {
        context.Tours.Add(tour);
      }

      public void Remove(Tour tour)
      {
        context.Remove(tour);
      }

      public async Task<List<Tour>> GetTours()
      {
        return await context.Tours
            .Include(h => h.Hotel)
            .Include(v => v.Sales)
            .ToListAsync();
      }
    
    }
}