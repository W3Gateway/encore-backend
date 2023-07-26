using AutoMapper;
using Encore.Application.Visits.Commands;
using Encore.Application.Visits.Responses;
using Encore.Domain.Models;

namespace Encore.Application.Visits
{
    public class VisitMappingProfile : Profile
    {
        public VisitMappingProfile()
        {
            CreateMap<Visit, VisitResponse>();

            CreateMap<VisitAnswerCreateCommand, QuestionAnswer>();
        }
    }
}
