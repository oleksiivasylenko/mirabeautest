using AutoMapper;

namespace Airports.Base.Configurations.Base
{
    public interface IAutoMapperConfiguration
    {
        void Configure(IMapperConfigurationExpression config);
    }
}
