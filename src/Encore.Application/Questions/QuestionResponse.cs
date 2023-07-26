using Encore.Domain.Models;

namespace Encore.Application.Questions
{
    public class QuestionResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int ResponseType { get; set; }
        public bool Mandatory { get; set; }
        public IEnumerable<OtherQuestionResponse>? OtherQuestions { get; set; }

        public QuestionResponse(Guid id, string name, int responseType, bool mandatory, List<OtherQuestionResponse> otherQuestions)
        {
            Id = id;
            Name = name;
            ResponseType = responseType;
            Mandatory = mandatory;
            OtherQuestions = otherQuestions;
        }
    }
}
