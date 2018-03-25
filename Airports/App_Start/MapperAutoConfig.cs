using Airports.Base.Configurations.Base;
using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace Airports.App_Start
{
    public class MapperAutoConfig
    {
        public static void Configure(IMapperConfigurationExpression cnf)
        {
            Assembly.Load("Airports.BLL");
            var type = typeof(IAutoMapperConfiguration);
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(p => type.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract).ToList();
            types.ForEach(c =>
            {
                var uc = (IAutoMapperConfiguration)Activator.CreateInstance(c);
                uc.Configure(cnf);
            });
        }
    }
}
