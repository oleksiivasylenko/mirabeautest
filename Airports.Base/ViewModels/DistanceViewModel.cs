using Airports.Base.DBModels;

namespace Airports.Base.ViewModels
{
    public class DistanceViewModel
    {
        #region props

        public int Distance { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        #endregion

        #region ctors

        public DistanceViewModel()
        {

        }

        public DistanceViewModel(double distance, Airport airportFrom, Airport airportTo)
        {
            Distance = (int)distance;
            From = airportFrom.Name;
            To = airportTo.Name;
        }

        #endregion
    }
}
