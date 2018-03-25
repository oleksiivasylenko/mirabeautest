using Airports.Base.Helpers;

namespace Airports.Base
{
    public static class GlobalVariables
    {
        public const string DbCollectionName = "airports";
        public const string AppInfoDbCollectionName = "appInfo";
        public static string LiteDbPath => $"{PhysicalPathFinder.GetAppDataFolder()}\\Airports.db";
        public const string JsonUrl = "https://raw.githubusercontent.com/jbrooksuk/JSON-Airports/master/airports.json";
        public static class Pagination
        {
            public const int AirportsPageSize = 10;
        }

        public static class ErrorMessages
        {
            public const string PleaseEnterFromAndTo = "Please enter (from) and (to) airports!";
            public const string ItemNotFoundException = "No airport with such IATA!";
            public const string EmptyParameterException = "Parameters must not be empty!";
        }
    }
}
