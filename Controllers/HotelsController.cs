

using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourAgency.Controllers.Resources;
using TourAgency.Core;
using TourAgency.Core.Models;
using TourAgency.Persistence;

namespace TourAgency.Controllers
{
    [Route("/api/hotels")]
    public class HotelsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHotelRepository repository;

        public HotelsController(IMapper mapper, IHotelRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<HotelResource>> GetHotels()
        {
            var hotels = await repository.GetHotels();
            return mapper.Map<List<Hotel>, List<HotelResource>>(hotels);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] HotelResource hotelResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Debug.WriteLine("Creaate hotel" + hotelResource.Name.ToString());

            
            var hotel = mapper.Map<HotelResource, Hotel>(hotelResource);

            repository.Add(hotel);
            await unitOfWork.CompleteAsync();

            hotel = await repository.GetHotel(hotel.Id);

            var result = mapper.Map<Hotel, HotelResource>(hotel);
            return Ok(result);
        }

        [HttpPut("{id}")]
    public async Task<IActionResult> UpdateHotel(int id, [FromBody] HotelResource hotelResource)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var hotel = await repository.GetHotel(id);

      if (hotel == null)
        return NotFound();

      mapper.Map<HotelResource, Hotel>(hotelResource, hotel);

      await unitOfWork.CompleteAsync();

      hotel = await repository.GetHotel(hotel.Id);
      var result = mapper.Map<Hotel, HotelResource>(hotel);

      return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHotel(int id)
    {
      var hotel = await repository.GetHotel(id, includeRelated: false);

      if (hotel == null)
        return NotFound();

      repository.Remove(hotel);
      await unitOfWork.CompleteAsync();

      return Ok(id);
    }
    }
}