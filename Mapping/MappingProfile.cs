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

            CreateMap<CountryResource, Country>();

            CreateMap<Tour, TourResource>()
            .ForMember(h=> h.Hotel, opt => opt.MapFrom(hr => hr.Hotel))
            .ForMember(h => h.Sales, opt => opt.MapFrom(hr => hr.Sales));
            
            CreateMap<Tour, SaveTourResource>();

            CreateMap<SaveTourResource,Tour>()
                .ForMember(h => h.Id, opt => opt.Ignore());

            CreateMap<Sale,SaleResource>()
            .ForMember(s => s.Person, opt => opt.MapFrom(sl => sl.Person))
            .ForMember(s => s.Tour, opt => opt.MapFrom(sl => sl.Tour));

            CreateMap<Sale,SaveSaleResource>();

            CreateMap<SaveSaleResource,Sale>()
                .ForMember(h => h.Id, opt => opt.Ignore());


            CreateMap<Person,PersonResource>();

            CreateMap<Hotel,HotelResource>()
            .ForMember(h=> h.Country, opt => opt.MapFrom(hr => hr.Country))
            .ForMember(h => h.Tours, opt => opt.MapFrom(hr => hr.Tours.Select(t => t.Id)));


            CreateMap<Hotel,SaveHotelResource>();

            CreateMap<SaveHotelResource,Hotel>()
                .ForMember(h => h.Id, opt => opt.Ignore());
        }
        
    }
}