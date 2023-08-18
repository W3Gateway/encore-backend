namespace Encore.Application.Persons.Responses
{
    public class PersonListResponse
    {
        public int AppId { get; set; }
        public Guid ApplicationId { get; set; }

        public PersonListResponse(int appId, Guid applicationId)
        {
            AppId = appId;
            ApplicationId = applicationId;
        }
    }
}
