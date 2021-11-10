using System.Collections.Generic;
using System.Threading.Tasks;
using TourAgency.Core.Models;

namespace TourAgency.Core
{
    public interface IHotelRepository
    {
        void Add(Hotel hotel);
        Task<Hotel> GetHotel(int id);
        void Remove(Hotel hotel);
        Task<List<Hotel>> GetHotels();
    }
}