using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TourAgency.Core;
using TourAgency.Core.Models;

namespace TourAgency.Persistence
{
    public class CountryRepository : ICountryRepository
    {
        private readonly TourAgencyDbContext context;

        public CountryRepository(TourAgencyDbContext context)
        {
            this.context = context;
        }
        
        public async Task<List<Country>> GetCountries()
        {
            return await context.Countries.ToListAsync();
        }

        public async Task<Country> GetCountry(int id, bool includeRelated = true)
        {
            if (!includeRelated)
            return await context.Countries.FindAsync(id);

            return await context.Countries
                .SingleOrDefaultAsync(v => v.Id == id);
        }

        public void Add(Country country)
        {
            context.Countries.Add(country);
        }

        public void Remove(Country country)
        {
            context.Remove(country);
        }
    }
}