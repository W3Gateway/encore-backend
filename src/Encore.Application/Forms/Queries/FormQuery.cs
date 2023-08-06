using Encore.Application.Forms.Responses;
using Encore.Domain.Core.Messaging;

namespace Encore.Application.Forms.Queries
{
    public class FormQuery : Query<FormResponse>
    {
        public string SlugForm { get; set; }
    }
}
