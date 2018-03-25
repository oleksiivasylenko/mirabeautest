using Airports.Base.Enums;
using Airports.Base.Interfaces;

namespace Airports.Base.ViewModels
{
    public class AirportViewModel : IViewModel
    {
        public string IATA { get; set; }
        public string ISO { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public AirportContinent Continent { get; set; }
        public AirportType Type { get; set; }
        public AirportSize Size { get; set; }
    }
}
