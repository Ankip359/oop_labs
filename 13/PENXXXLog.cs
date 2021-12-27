using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace laba13
{
    public class PENXXXLog
    {
        private static readonly string basepath = @"Q:\labaratornii\2 курс\ООП\lab13\xxxlog.txt";

        static PENXXXLog()
        {
            var fileInf = new FileInfo(basepath);
            if (!fileInf.Exists)
                using (new FileStream(basepath, FileMode.Create)) { }
        }

        public void Write(string action)
        {            
            var Writer = new StreamWriter(basepath, true, System.Text.Encoding.UTF8);
            Writer.WriteLine($"action: {action}; date: {DateTime.Now}");
            Writer.Close();
        }

        public string Read()
        {
            var Reader = new StreamReader(basepath);
            string line = Reader.ReadToEnd();
            
            return line;
        }

        public List<string> Find(DateTime date)
        {
            string data = Read();
            List<string> result = new List<string>();

            foreach (var field in data.Split('\n').Where(val => val != ""))
            {
                var splitArr = field.Split(' ');
                string dateStr = splitArr[splitArr.Length - 1];
                var fielddate = DateTime.Parse(dateStr);
                if (fielddate < date) {
                    result.Add(field);
                }   
            }

            return result;
        }
    }
}