using System;
using System.IO;
using System.IO.Compression;

namespace laba13
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string basePath = @"Q:\labaratornii\2 курс\ООП\lab13";
            
            Console.WriteLine("1##########################################");
            PENXXXDiskInfo.DisksInf();
            
            Console.WriteLine("2##########################################");
            var fileInf = new PENXXXFileInfo(Path.Combine(basePath, @"asdasd.mcd"));
            fileInf.FileDates();
            fileInf.FileInf();
            fileInf.FullPath();
            
            Console.WriteLine("3##########################################");
            var dirInf = new PENXXXDirInfo(Path.Combine(basePath, @"teafolder"));
            dirInf.CreateTime();
            dirInf.FilesCount();
            dirInf.ParentDirs();

            var fileWriter = new PENXXXFileManager(Path.Combine(basePath, @"asdasd.txt"));
            try
            {
                fileWriter.Write("huh");
                fileWriter.CopyTo(Path.Combine(basePath, @"asdasdCopy.txt"));
                fileWriter.Remove();
                new PENXXXFileManager(Path.Combine(basePath, @"asdasdCopy.txt")).MoveTo(Path.Combine(basePath, @"asdasdCopyRenamed.txt"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("6##########################################");
            var result = new PENXXXLog().Find(DateTime.Now.AddHours(1));
            foreach (var s in result)
            {
                Console.WriteLine(s);
            }
        }
    }
}