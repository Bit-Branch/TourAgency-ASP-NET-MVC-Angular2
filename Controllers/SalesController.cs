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
    public class SalesController
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
    }
}