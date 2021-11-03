using AutoMapper;
using System.Linq;
using TourAgency.Controllers.Resources;
using TourAgency.Core.Models;

namespace TourAgency.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile(){
            
            CreateMap<Country, CountryResource>();
            CreateMap<Tour, TourResource>();
            CreateMap<Sale,SaleResource>();
            CreateMap<Hotel,HotelResource>();
            CreateMap<Person,PersonResource>();

            CreateMap<HotelResource,Hotel>()
                .ForMember(h => h.Country, opt => opt.Ignore())
                .ForMember(h => h.Tours, opt => opt.Ignore());
        }
        
    }
}