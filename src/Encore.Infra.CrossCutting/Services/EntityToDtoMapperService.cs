using AutoMapper;
using Encore.Domain.Interfaces.CrossCutting;
using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;

namespace Encore.Infra.CrossCutting.Services
{
    public class EntityToDtoMapperService<TSource, TDestination> : IEntityToDtoMapper<TSource, TDestination>
    {
        private readonly IMapper _mapper;

        public EntityToDtoMapperService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Mapeie aqui as propriedades específicas que deseja ignorar, se necessário
                // cfg.CreateMap<ClasseEntidade, ClasseDTOResultado>().ForMember(dest => dest.Propriedade, opt => opt.Ignore());

                cfg.CreateMap<TSource, TDestination>();
            });

            _mapper = config.CreateMapper();
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }
    }
}
