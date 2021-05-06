using System;
using System.IO;
using System.Text;

namespace LogCustom
{
    sealed class LogWriter
    {
        StringBuilder _nameOfFile = new StringBuilder(Directory.CreateDirectory("Logs") + @".\" +
            "\\" + "log " + DateTime.UtcNow.ToString("yyyy-MM-dd_") + 1.ToString() + ".txt");

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
            FileInfo fileInfo = new FileInfo(_nameOfFile.ToString());
            int counterFileName = 1;
        startloop:
            if (File.Exists(_nameOfFile.ToString()))
            {
                FileInfo fileInfo1 = new FileInfo(_nameOfFile.ToString());
                if (fileInfo.Length > 30_000 && fileInfo1.Length > 30_000)
                {
                    _nameOfFile.Remove(22, 1);
                    counterFileName++;
                    _nameOfFile.Insert(22, counterFileName.ToString());
                    goto startloop;
                }
            }
            return _nameOfFile.ToString();
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
