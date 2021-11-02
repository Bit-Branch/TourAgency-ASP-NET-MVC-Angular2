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
        private readonly TourAgencyDbContext context;

        public ToursController(TourAgencyDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<CountryResource>> GetTours()
        {
        var features = await context.Countries.ToListAsync();

        
        return mapper.Map<List<Country>, List<CountryResource>>(features); 
        }
    }
}