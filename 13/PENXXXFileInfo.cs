using System;
using System.IO;

namespace laba13
{
    public class PENXXXFileInfo
    {
        public FileInfo fileInf { get; set; }
        private static PENXXXLog logger { get; } = new PENXXXLog();

        public PENXXXFileInfo(string path)
        {
            fileInf = new FileInfo(path);
        }

        public void FullPath()
        {
            logger.Write("FullFilePath");
            Console.WriteLine($"filepath - {fileInf.DirectoryName}");
        }
        
        public void FileInf()
        {
            logger.Write("FileInf");
            Console.WriteLine($"size - {fileInf.Length}; ext - {fileInf.Extension}; name - {fileInf.Name}");
        }
        
        public void FileDates()
        {
            logger.Write("FileDates");
            Console.WriteLine($"create time - {fileInf.CreationTimeUtc.ToLongDateString()}; edit time - {fileInf.LastWriteTimeUtc.ToLongDateString()}");
        }
    }
}