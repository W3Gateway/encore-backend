using AutoMapper;
using Encore.Domain.Models;

namespace Encore.Application.Addresses
{
    public class AddressMappingProfile : Profile
    {
        public AddressMappingProfile()
        {
            CreateMap<Address, AddressResponse>();
            CreateMap<AddressCommand, Address>();
        }
    }
}
