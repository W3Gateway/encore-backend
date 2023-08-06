using AutoMapper;
using Encore.Application.Forms.Queries;
using Encore.Application.Forms.Responses;
using Encore.Domain.Enum;
using Encore.Domain.Interfaces.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Encore.Application.Forms.Handlers
{
    public class FormQueryHandler : IRequestHandler<FormQuery, FormResponse>
    {
        private readonly IFormRepository _formRepository;
        private readonly IMapper _mapper;

        public FormQueryHandler(IFormRepository questionRepository,
                                        IMapper mapper)
        {
            _formRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<FormResponse> Handle(FormQuery request, CancellationToken cancellationToken)
        {
            var value = (EFormType)Enum.Parse(typeof(EFormType), request.SlugForm);

            var form = await _formRepository.Include().Where(f => f.Slug.Equals(value))
                .Include(f => f.Questions.OrderBy(q=>q.Order)).ThenInclude(q => q.OtherQuestions.OrderBy(oq=>oq.Name))
                .ThenInclude(oq => oq.SubQuestion).ThenInclude(sq => sq.OtherQuestions.OrderBy(oq=>oq.Name))
                .FirstOrDefaultAsync();

            if (form is null)
                return null;

            var response = _mapper.Map<FormResponse>(form);

            return response;
        }
    }
}