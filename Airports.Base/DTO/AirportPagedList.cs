using Airports.Base.ViewModels;
using System.Collections.Generic;

namespace Airports.Base.DTO
{
    public class AirportPagedList
    {
        #region props

        public int TotalItems { get; set; }

        public List<AirportViewModel> Airports { get; set; }

        #endregion

        #region ctors

        public AirportPagedList()
        {
            Airports = new List<AirportViewModel>();
        }

        public AirportPagedList(List<AirportViewModel> airports, int total) : this()
        {
            Airports = airports;
            TotalItems = total;
        }

        #endregion
    }
}
