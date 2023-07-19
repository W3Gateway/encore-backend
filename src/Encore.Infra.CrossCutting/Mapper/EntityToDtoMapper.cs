using AutoMapper;
using Encore.Domain.Interfaces.CrossCutting;

namespace Encore.Infra.CrossCutting.Services
{

    public class EntityToDtoMapper<TEntity, TDTO> : IEntityToDtoMapper<TEntity, TDTO> 
    {
        private readonly IMapper _mapper;

        public EntityToDtoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TEntity, TDTO>();
            });

            _mapper = config.CreateMapper();
        }

        public TDTO Map(TEntity entity)
        {
            return _mapper.Map<TDTO>(entity);
        }

        public List<TDTO> MapList(List<TEntity> entities)
        {
            return _mapper.Map<List<TDTO>>(entities);
        }
    }
}
