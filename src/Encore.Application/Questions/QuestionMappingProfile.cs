using AutoMapper;
using Encore.Application.Questions.Queries;
using Encore.Application.Questions.Responses;
using Encore.Domain.Models;

namespace Encore.Application.Questions
{
    public class QuestionMappingProfile : Profile
    {
        public QuestionMappingProfile()
        {
            CreateMap<QuestionListQuery, Question>();

            CreateMap<Question, QuestionResponse>();

            CreateMap<OtherQuestion, OtherQuestionResponse>();
        }
    }
}
