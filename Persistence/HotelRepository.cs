using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TourAgency.Core;
using TourAgency.Core.Models;

namespace TourAgency.Persistence
{
    public class HotelRepository : IHotelRepository
    {
        private readonly TourAgencyDbContext context;

        public HotelRepository(TourAgencyDbContext context)
        {
            this.context = context;
        }

        public void Add(Hotel hotel)
        {
            Console.WriteLine(hotel.Name);
            context.Hotels.Add(hotel);
        }

        public async Task<Hotel> GetHotel(int id)
        {
            return await context.Hotels
                .Include(h => h.Country)
                .Include(v => v.Tours)
                .SingleOrDefaultAsync(v => v.Id == id);
        }

        public async Task<List<Hotel>> GetHotels()
        {
            return await context.Hotels
            .Include(h => h.Country)
            .Include(v => v.Tours).ToListAsync();
        }

        public void Remove(Hotel hotel)
        {
            context.Remove(hotel);
        }
    }
}