using Airports.Base.Enums;
using System;

namespace Airports.Base.Helpers
{
    public static class GeoDistanceCalculator
    {
        #region public funcs

        public static double Calculate(double lat1, double lon1, double lat2, double lon2, DistanceMeasuringUnit unit)
        {
            double theta = lon1 - lon2;
            double dist = Math.Sin(Deg2rad(lat1)) * Math.Sin(Deg2rad(lat2))
                        + Math.Cos(Deg2rad(lat1)) * Math.Cos(Deg2rad(lat2)) * Math.Cos(Deg2rad(theta));

            dist = Math.Acos(dist);
            dist = Rad2deg(dist);
            dist = dist * 60 * 1.1515;

            if (unit == DistanceMeasuringUnit.Kilometers)
                dist = dist * 1.609344;
            else if (unit == DistanceMeasuringUnit.NauticalMiles)
                dist = dist * 0.8684;

            return (dist);
        }

        #endregion

        #region private funcs

        private static double Deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        private static double Rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }

        #endregion
    }
}
