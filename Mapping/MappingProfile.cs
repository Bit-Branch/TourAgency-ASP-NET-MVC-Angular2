using AutoMapper;
using TourAgency.Controllers.Resources;
using TourAgency.Core.Models;

namespace TourAgency.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile(){
            CreateMap<Country, CountryResource>();
        }
        
    }
}