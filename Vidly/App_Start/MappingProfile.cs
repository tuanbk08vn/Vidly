using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<CustomerViewModel, Customer>();

            CreateMap<CustomerViewModel, CustomerFormViewModel>();
            CreateMap<CustomerFormViewModel, CustomerViewModel>();

            CreateMap<Customer, CustomerFormViewModel>();
            CreateMap<CustomerFormViewModel, Customer>();

            CreateMap<MembershipType, CustomerFormViewModel>();
            CreateMap<CustomerFormViewModel, MembershipType>();

            CreateMap<Movie, MovieViewModel>();
            CreateMap<MovieViewModel, Movie>();

            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();

            CreateMap<MembershipType, MembershipTypeDto>();
            CreateMap<MembershipTypeDto, MembershipType>();
            //CreateMap<Customer, CustomerDto>().ForMember(m => m.Id, opt => opt.Ignore());

            CreateMap<RentalViewModel, Rental>();
            CreateMap<Rental, RentalViewModel>();

            CreateMap<NewRentalDto, Rental>();
            CreateMap<Rental, NewRentalDto>();


        }
    }
}