using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;
using Encore.Infra.Data.Context;

namespace Encore.Infra.Data.Repositories
{
    public class QuestionAnswerRepository : Repository<QuestionAnswer>, IQuestionAnswerRepository
    {
        public QuestionAnswerRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}
