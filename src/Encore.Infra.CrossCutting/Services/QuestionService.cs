using Encore.Domain.Interfaces.CrossCutting;
using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;

namespace Encore.Infra.CrossCutting.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<List<Question>> GetAll()
        {
            return await _questionRepository.GetAsync();
        }
    }
}
