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
    }
}