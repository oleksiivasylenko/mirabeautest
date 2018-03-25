using Airports.Base.Enums;

namespace Airports.Base.Filters
{
    public class AirportFilter
    {
        #region props

        public AirportContinent? Continent { get; set; }

        public AirportSize? Size { get; set; }

        public AirportType? Type { get; set; }

        public string ISO { get; set; }

        public string Name { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        #endregion

        #region ctors

        public AirportFilter()
        {
            Page = 1;
            PageSize = GlobalVariables.Pagination.AirportsPageSize;
        }

        #endregion
    }
}
