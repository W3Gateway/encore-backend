namespace Encore.Domain.Interfaces.CrossCutting
{
    public interface IEntityToDtoMapper<TSource, TDestination>
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }
}
