using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TourAgency.Core;
using TourAgency.Core.Models;

namespace TourAgency.Persistence
{
    public class PersonRepository : IPersonRepository
    {
        private readonly TourAgencyDbContext context;

        public PersonRepository(TourAgencyDbContext context)
        {
            this.context = context;
        }

        public void Add(Person person)
        {
            context.People.Add(person);
        }

        public async Task<List<Person>> GetPeople()
        {
            return await context.People
            .Include(h => h.Sales).ToListAsync();
        }

        public Task<Person> GetPerson(int id, bool includeRelated = true)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Person person)
        {
            context.People.Remove(person);
        }
    }
}