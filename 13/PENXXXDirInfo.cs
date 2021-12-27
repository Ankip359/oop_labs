using System;
using System.IO;

namespace laba13
{
    public class PENXXXDirInfo
    {
        public DirectoryInfo dirInf { get; set; }
        private static PENXXXLog logger { get; } = new PENXXXLog();

        public PENXXXDirInfo(string path)
        {
            dirInf = new DirectoryInfo(path);
        }

        public void FilesCount()
        {
            logger.Write("FilesCount");
            Console.WriteLine($"files count - {dirInf.GetFiles().Length}");
        }
        
        public void CreateTime()
        {
            logger.Write("CreateFolderTime");
            Console.WriteLine($"create time - {dirInf.CreationTime.ToLongTimeString()}");
        }
        
        public void SubdirsCount()
        {
            logger.Write("SubdirsCount");
            Console.WriteLine($"subdirs count - {dirInf.GetDirectories().Length}");
        }
        
        public void ParentDirs()
        {
            logger.Write("ParentDirs");
            Console.WriteLine($"parent dirs - {dirInf.Parent.Name}");
        }
    }
}