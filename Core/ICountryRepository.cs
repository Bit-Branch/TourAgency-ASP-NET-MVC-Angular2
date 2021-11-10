using System.Collections.Generic;
using System.Threading.Tasks;
using TourAgency.Core.Models;

namespace TourAgency.Core
{
    public interface ICountryRepository
    {
        Task<Country> GetCountry(int id, bool includeRelated = true);

        Task<List<Country>> GetCountries();

        void Add(Country country);

        void Remove(Country country);
    }
}