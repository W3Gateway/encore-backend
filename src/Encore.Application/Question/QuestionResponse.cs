using Encore.Domain.Core.Responses;

namespace Encore.Application.Auth
{
    public class QuestionResponse : Response<QuestionResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int ResponseType { get; set; }
        public bool Mandatory { get; set; }

        public QuestionResponse(string id, string name, int responseType, bool mandatory)
        {
            Id = id;
            Name = name;
            ResponseType = responseType;
            Mandatory = mandatory;
        }
    }
}
