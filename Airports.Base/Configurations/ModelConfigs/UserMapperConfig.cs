using Airports.Base.Configurations.Base;
using Airports.Base.DBModels;
using Airports.Base.ViewModels;
using AutoMapper;

namespace Airports.Base.Configurations.ModelConfigs
{
    public class UserMapperConfig : IAutoMapperConfiguration
    {
        public void Configure(IMapperConfigurationExpression config)
        {
            config.CreateMap<Airport, AirportViewModel>();
            config.CreateMap<AirportViewModel, Airport>();
        }
    }
}
