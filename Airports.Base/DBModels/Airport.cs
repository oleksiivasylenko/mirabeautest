using Airports.Base.DTO;
using Airports.Base.Enums;
using Airports.Base.Extensions;
using Airports.Base.Interfaces;
using System;
using System.Globalization;

namespace Airports.Base.DBModels
{
    public class Airport : IEntity
    {
        #region props

        public Guid Id { get; set; }
        public string IATA { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public string ISO { get; set; }
        public string Country { get; set; }
        public int Status { get; set; }
        public string Name { get; set; }
        public AirportContinent Continent { get; set; }
        public AirportType Type { get; set; }
        public AirportSize Size { get; set; }

        #endregion

        #region ctors

        public Airport()
        {

        }

        public Airport(AirportDTO airportDTO)
        {
            IATA = airportDTO.IATA;
            Lon = Convert.ToDouble(airportDTO.Lon);
            Lat = Convert.ToDouble(airportDTO.Lat);
            ISO = airportDTO.ISO;

            try
            {
                Country = new RegionInfo(ISO).EnglishName;
            }
            catch (Exception)
            {
                Country = "Unknown code";
            }

            Status = airportDTO.Status;
            Name = string.IsNullOrEmpty(airportDTO.Name) ? "Unknown" : airportDTO.Name;

            Continent = airportDTO.Continent.ToEnum(AirportContinent.Unknown);
            Type = airportDTO.Type.ToEnum(AirportType.Unknown);
            Size = airportDTO.Size.ToEnum(AirportSize.Unknown);
        }

        #endregion
    }
}
