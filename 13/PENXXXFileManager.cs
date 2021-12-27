using System;
using System.IO;

namespace laba13
{
    public class PENXXXFileManager
    {
        private FileInfo file { get; set; }
        private static PENXXXLog logger { get; } = new PENXXXLog();

        public PENXXXFileManager(string path)
        {
            file = new FileInfo(path);
        }

        public void MoveTo(string newPath)
        {
            logger.Write("move");
            file.MoveTo(newPath);
        }

        public void Remove()
        {
            logger.Write("remove");
            file.Delete();
        }

        public void CopyTo(string path)
        {
            logger.Write("copy");
            file.CopyTo(path);
        }

        public void Write(string data)
        {
            logger.Write("write");
            var encData = System.Text.Encoding.Default.GetBytes(data);
            using(var fileWrite = file.OpenWrite())
            {
                fileWrite.Write(encData, 0, encData.Length);
            }
        }
    }
}