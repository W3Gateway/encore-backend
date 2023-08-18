namespace Encore.Application.Homes.Responses
{
    public class HomeListResponse
    {
        public int AppId { get; set; }
        public Guid ApplicationId { get; set; }

        public HomeListResponse(int appId, Guid applicationId)
        {
            AppId = appId;
            ApplicationId = applicationId;
        }
    }
}
