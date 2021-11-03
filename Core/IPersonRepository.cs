using System.Collections.Generic;
using System.Threading.Tasks;
using TourAgency.Core.Models;

namespace TourAgency.Core
{
    public interface IPersonRepository
    {
        Task<Person> GetPerson(int id, bool includeRelated = true);

        void Add(Person person);

        void Remove(Person person);

        Task<List<Person>> GetPeople();
    }
}