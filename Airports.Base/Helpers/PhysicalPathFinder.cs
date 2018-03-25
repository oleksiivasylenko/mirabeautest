using System;
using System.IO;

namespace Airports.Base.Helpers
{
    public static class PhysicalPathFinder
    {
        public static string GetAppDataFolder()
        {
            string dirName = AppDomain.CurrentDomain.BaseDirectory; // Starting Dir
            FileInfo fileInfo = new FileInfo(dirName);
            DirectoryInfo parentDir = fileInfo.Directory.Parent.Parent;
            string parentDirName = parentDir.FullName;

            return dirName + "\\App_Data";
        }
    }
}
