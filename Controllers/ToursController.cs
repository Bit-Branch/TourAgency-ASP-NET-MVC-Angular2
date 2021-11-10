using System.Collections.Generic;
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
    [Route("/api/tours")]
    public class ToursController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ITourRepository repository;

        public ToursController(IMapper mapper, ITourRepository repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TourResource>> GetTours()
        {
            var tours = await repository.GetTours();
            
            return mapper.Map<List<Tour>, List<TourResource>>(tours);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTour(int id)
        {
            var tour = await repository.GetTour(id);

            if (tour == null)
              return NotFound();

            var hotelResource = mapper.Map<Tour, TourResource>(tour);

            return Ok(hotelResource);
        }


        [HttpPost]
        public async Task<IActionResult> CreateTour([FromBody] SaveTourResource tourResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var tour = mapper.Map<SaveTourResource, Tour>(tourResource);

            repository.Add(tour);
            await unitOfWork.CompleteAsync();

            tour = await repository.GetTour(tour.Id);

            var result = mapper.Map<Tour, TourResource>(tour);
            return Ok(result);
        }

        
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateHotel(int id, [FromBody] SaveTourResource tourResource)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var tour = await repository.GetTour(id);

      if (tour == null)
        return NotFound();

      mapper.Map<SaveTourResource, Tour>(tourResource, tour);

      await unitOfWork.CompleteAsync();

      tour = await repository.GetTour(tour.Id);
      var result = mapper.Map<Tour, TourResource>(tour);

      return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTour(int id)
    {
      var tour = await repository.GetTour(id);

      if (tour == null)
        return NotFound();

      repository.Remove(tour);
      await unitOfWork.CompleteAsync();

      return Ok(id);
    }
    }
}