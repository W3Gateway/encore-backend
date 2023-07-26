namespace Encore.Application.Questions
{
    public class OtherQuestionResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public OtherQuestionResponse(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
