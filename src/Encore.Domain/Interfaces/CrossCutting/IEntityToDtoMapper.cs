namespace Encore.Domain.Interfaces.CrossCutting
{
    public interface IEntityToDtoMapper<TEntity, TDTO>
    {
        TDTO Map(TEntity entity);

        List<TDTO> MapList(List<TEntity> entities);
    }
}
