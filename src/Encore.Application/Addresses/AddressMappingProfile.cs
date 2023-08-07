using AutoMapper;
using Encore.Application.Homes.Commands;
using Encore.Domain.Models;

namespace Encore.Application.Addresses
{
    public class AddressMappingProfile : Profile
    {
        public AddressMappingProfile()
        {
            CreateMap<Address, AddressResponse>();
            CreateMap<HomeCreateCommand, Address>();
        }
    }
}
