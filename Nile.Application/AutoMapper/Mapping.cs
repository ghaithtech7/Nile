using AutoMapper;

namespace Nile.Application.AutoMapper
{
    public static class Mapping<TDestination, TSource>
    {
        private static Mapper mapper = new Mapper(new MapperConfiguration(config =>
            config.CreateMap<TDestination, TSource>().ReverseMap()
        ));
    }
}