namespace Encore.Application.Questions.Responses
{
    public class OtherQuestionResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public QuestionResponse? SubQuestion { get; set; }

        public OtherQuestionResponse(Guid id, string name, QuestionResponse? subQuestion)
        {
            Id = id;
            Name = name;
            SubQuestion = subQuestion;
        }
    }
}
