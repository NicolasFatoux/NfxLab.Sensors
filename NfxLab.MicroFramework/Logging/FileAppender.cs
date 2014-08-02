using System;
using Microsoft.SPOT;
using System.IO;

namespace NfxLab.MicroFramework.Logging
{
    public class FileAppender : IAppender
    {
        StreamWriter writer;

        public FileAppender(string path)
        {
            var stream = File.Open(path, FileMode.Append);
            writer = new StreamWriter(stream);
        }

        public void Write(string message)
        {
            try
            {
                writer.WriteLine(message);
            }
            catch
            {
            }
        }
    }
}
