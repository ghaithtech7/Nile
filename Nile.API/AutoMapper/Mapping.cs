using AutoMapper;

namespace Nile.API.AutoMapper
{
    public static class Mapping<TDestination, TSource>
    {
        private static Mapper mapper = new Mapper(new MapperConfiguration(config =>
        config.CreateMap<TDestination, TSource>().ReverseMap()
    ));

        /* public static TDestination Map(TSource source)
         {
             return Mapper.Map<TDestination>(source);
         }
         public static TDestination Maps(TDestination destination, TSource source)
         {
             return Mapper.Map<TSource, TDestination>(source, destination);
         }*/
        /*public static List<TDestination> MapList(List<TSource> source)
        {
            List<TDestination> list = new List<TDestination>();

            source.ForEach(item => list.Add(Map(item)));

            return list;
        }*/
    }
}