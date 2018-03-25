using System;

namespace Airports.Base.DBModels
{
    public class AppInfo
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool NeedSendHeader { get; set; }

        public AppInfo()
        {
            NeedSendHeader = true;
            Name = GlobalVariables.AppInfoDbCollectionName;
        }
    }
}
