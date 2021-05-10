using System;
using System.IO;
using System.Text;

namespace LogCustom
{
    sealed class LogWriter
    {
        internal void LogWriteDebug(string logMessage)
        {
            using (StreamWriter streamWriter = File.AppendText(CheckNameOfFile()))
            {
                LogForDebug(logMessage, streamWriter);
            }
        }

        void LogWriteInfo(string logMessage)
        {
            using (StreamWriter streamWriter = File.AppendText(CheckNameOfFile()))
            {
                LogForInfo(logMessage, streamWriter);
            }
        }

        internal void LogWriteError(string logMessage)
        {
            using (StreamWriter streamWriter = File.AppendText(CheckNameOfFile()))
            {
                LogForError(logMessage, streamWriter);
            }
        }

        string CheckNameOfFile()
        {
            string file = Directory.CreateDirectory("Logs") + @".\\" +
            "log " + DateTime.UtcNow.ToString("yyyy-MM-dd_");
            string format = ".txt";
            int counterFileName = 1;
        
            string nameOfFile = file + counterFileName + format;
        startloop:
            FileInfo fileInfo = new FileInfo(nameOfFile);

            if (File.Exists(nameOfFile))
            {
                if (fileInfo.Length > 30_000)
                {
                    counterFileName++;
                    nameOfFile = file + counterFileName + format;
                    goto startloop;
                }
            }
            return nameOfFile;
        }

        void LogForDebug(string logMessage, TextWriter txtWriter)
        {
            txtWriter.Write("\r\n[Debug]: ");
            txtWriter.WriteLine("(UTC) {0} {1}", DateTime.UtcNow.ToLongTimeString(),
                DateTime.UtcNow.ToLongDateString());
            txtWriter.WriteLine($"{logMessage}");
            txtWriter.WriteLine("_______________________________");
        }

        void LogForInfo(string logMessage, TextWriter txtWriter)
        {
            txtWriter.Write("\r\n[Info]: ");
            txtWriter.WriteLine("(UTC) {0} {1}", DateTime.UtcNow.ToLongTimeString(),
                DateTime.UtcNow.ToLongDateString());
            txtWriter.WriteLine($"{logMessage}");
            txtWriter.WriteLine("_______________________________");
        }

        void LogForError(string logMessage, TextWriter txtWriter)
        {
            txtWriter.Write("\r\n[Error]: ");
            txtWriter.WriteLine("(UTC) {0} {1}", DateTime.UtcNow.ToLongTimeString(),
                DateTime.UtcNow.ToLongDateString());
            txtWriter.WriteLine($"{logMessage}");
            txtWriter.WriteLine("_______________________________");
        }
    }
}
