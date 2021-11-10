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
    [Route("/api/countries")]
    public class CountriesController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ICountryRepository repository;

        public CountriesController(IMapper mapper, ICountryRepository repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CountryResource>> GetCountries()
        {
            var countries = await repository.GetCountries();
            return mapper.Map<List<Country>, List<CountryResource>>(countries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountry(int id)
        {
            var country = await repository.GetCountry(id);

            if (country == null)
              return NotFound();

            var countryResource = mapper.Map<Country, CountryResource>(country);

            return Ok(countryResource);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCountry([FromBody] CountryResource countryResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var country = mapper.Map<CountryResource, Country>(countryResource);

            repository.Add(country);
            await unitOfWork.CompleteAsync();

            country = await repository.GetCountry(country.Id);

            var result = mapper.Map<Country, CountryResource>(country);
            return Ok(result);
        }

        [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCountry(int id, [FromBody] CountryResource coutryResource)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var country = await repository.GetCountry(id);

      if (country == null)
        return NotFound();

      mapper.Map<CountryResource, Country>(coutryResource, country);

      await unitOfWork.CompleteAsync();

      country = await repository.GetCountry(country.Id);
      var result = mapper.Map<Country, CountryResource>(country);

      return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCountry(int id)
    {
      var country = await repository.GetCountry(id);

      if (country == null)
        return NotFound();

      repository.Remove(country);
      await unitOfWork.CompleteAsync();

      return Ok(id);
    }
    }
}