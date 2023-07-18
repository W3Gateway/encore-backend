using Encore.Domain.Core.Responses;
using Encore.Domain.Interfaces.CrossCutting;

namespace Encore.Application.Auth
{
    public class QuestionResponse : Response<QuestionResponse>
    {
        private readonly IEntityToDtoMapper<QuestionResponse, QuestionResponseDTO> _mapper;

        public List<QuestionResponseDTO> Questions { get; set; }

        public QuestionResponse(List<QuestionResponse> questions)
        {
            questions.ForEach(x =>
            {
                Questions.Add(_mapper.Map<QuestionResponse, QuestionResponseDTO>(x));
            });             
        } 
    }

    public class QuestionResponseDTO
    {
        public string Name { get; set; }
        public int ResponseType { get; set; }
        public bool Mandatory { get; set; }
    }
}
