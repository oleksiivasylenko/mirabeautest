using Airports.Base.Interfaces;
using AutoMapper;

namespace Airports.Extensions
{
    public static class AutoMapperConvertorExtensions
    {
        public static IEntity ToEntity<IEntity>(this IViewModel from)
        {
            return Mapper.Map<IEntity>(from);
        }

        public static IViewModel ToViewModel<IViewModel>(this IEntity from)
        {
            return Mapper.Map<IViewModel>(from);
        }
    }
}
