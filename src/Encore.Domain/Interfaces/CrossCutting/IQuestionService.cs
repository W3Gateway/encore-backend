using Encore.Domain.Models;

namespace Encore.Domain.Interfaces.CrossCutting
{
    public interface IQuestionService
    {
        Task<List<Question>> GetAll();
    }
}
