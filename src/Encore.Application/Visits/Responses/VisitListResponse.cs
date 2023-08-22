namespace Encore.Application.Visits.Responses
{
    public class VisitListResponse
    {
        public int AppId { get; set; }
        public Guid ApplicationId { get; set; }

        public VisitListResponse(int appId, Guid applicationId)
        {
            AppId = appId;
            ApplicationId = applicationId;
        }
    }
}
