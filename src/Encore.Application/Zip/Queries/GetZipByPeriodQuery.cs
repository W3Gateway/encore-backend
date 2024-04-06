using Encore.Application.Zip.Responses;
using Encore.Domain.Core.Messaging;

namespace Encore.Application.Zip.Queries
{
    public class GetZipByPeriodQuery : Query<ZipResponse>
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

        public GetZipByPeriodQuery() { }

        public GetZipByPeriodQuery(DateTime begin, DateTime end)
        {
            BeginDate = begin;
            EndDate = end;
        }
    }
}
