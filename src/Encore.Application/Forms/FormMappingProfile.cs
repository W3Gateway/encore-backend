using AutoMapper;
using Encore.Domain.Models;
using Encore.Application.Forms.Responses;

namespace Encore.Application.Forms
{
    public class FormMappingProfile : Profile
    {
        public FormMappingProfile()
        {
            CreateMap<Form, FormResponse>();
        }
    }
}
