
using System;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotel(int id)
        {
            var hotel = await repository.GetHotel(id);

            if (hotel == null)
              return NotFound();

            var hotelResource = mapper.Map<Hotel, HotelResource>(hotel);

            return Ok(hotelResource);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] SaveHotelResource hotelResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var hotel = mapper.Map<SaveHotelResource, Hotel>(hotelResource);

            repository.Add(hotel);
            await unitOfWork.CompleteAsync();

            hotel = await repository.GetHotel(hotel.Id);

            var result = mapper.Map<Hotel, HotelResource>(hotel);
            return Ok(result);
        }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateHotel(int id, [FromBody] SaveHotelResource hotelResource)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var hotel = await repository.GetHotel(id);

      if (hotel == null)
        return NotFound();

      mapper.Map<SaveHotelResource, Hotel>(hotelResource, hotel);

      await unitOfWork.CompleteAsync();

      hotel = await repository.GetHotel(hotel.Id);
      var result = mapper.Map<Hotel, HotelResource>(hotel);

      return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHotel(int id)
    {
      var hotel = await repository.GetHotel(id);

      if (hotel == null)
        return NotFound();

      repository.Remove(hotel);
      await unitOfWork.CompleteAsync();

      return Ok(id);
    }
    }
}