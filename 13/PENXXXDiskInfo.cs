using System;
using System.IO;
using System.Linq;

namespace laba13
{
    public class PENXXXDiskInfo
    {
        private static PENXXXLog logger { get; } = new PENXXXLog();
        
        public static void DisksInf()
        {
            logger.Write("DisksInf");
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (var drive in drives)
            {
                if(drive.IsReady)
                    Console.WriteLine($"{drive.Name} - available space = {drive.AvailableFreeSpace}; total space = {drive.TotalSize}; mark({drive.VolumeLabel})");
            }
        }
    }
}