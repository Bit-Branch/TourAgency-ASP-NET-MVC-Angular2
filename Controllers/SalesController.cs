

using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TourAgency.Controllers.Resources;
using TourAgency.Core;
using TourAgency.Core.Models;

namespace TourAgency.Controllers
{
    [Route("/api/sales")]
    public class SalesController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ISaleRepository repository;

        public SalesController(IMapper mapper, ISaleRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<SaleResource>> GetSales()
        {
            var sales = await repository.GetSales();
            return mapper.Map<List<Sale>, List<SaleResource>>(sales);
        }

         [HttpGet("{id}")]
        public async Task<IActionResult> GetSale(int id)
        {
            var sale = await repository.GetSale(id);

            if (sale == null)
              return NotFound();

            var saleResource = mapper.Map<Sale, SaleResource>(sale);

            return Ok(saleResource);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSale([FromBody] SaveSaleResource saleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var sale = mapper.Map<SaveSaleResource, Sale>(saleResource);

            repository.Add(sale);
            await unitOfWork.CompleteAsync();

            sale = await repository.GetSale(sale.Id);

            var result = mapper.Map<Sale, SaleResource>(sale);
            return Ok(result);
        }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSale(int id, [FromBody] SaveSaleResource saleResource)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var sale = await repository.GetSale(id);

      if (sale == null)
        return NotFound();

      mapper.Map<SaveSaleResource, Sale>(saleResource, sale);

      await unitOfWork.CompleteAsync();

      sale = await repository.GetSale(sale.Id);
      var result = mapper.Map<Sale, SaleResource>(sale);

      return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSale(int id)
    {
      var sale = await repository.GetSale(id);

      if (sale == null)
        return NotFound();

      repository.Remove(sale);
      await unitOfWork.CompleteAsync();

      return Ok(id);
    }
    }
}