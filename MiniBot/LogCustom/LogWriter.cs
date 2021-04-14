using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace LogCustom
{
    sealed class LogWriter
    {
        StringBuilder _nameOfFile = new StringBuilder(@"C:\Users\user\source\repos\AntonKastsiuchyk\ITAcademy.MiniBot\MiniBot\MiniBot\bin\Debug\net5.0\Logs" + 
            "\\" + "log " + DateTime.UtcNow.ToString("yyyy-MM-dd_") + 1.ToString() + ".txt");

        internal void LogWriteDebug(string logMessage)
        { 
            FileInfo fileInfo = new FileInfo(_nameOfFile.ToString());
            int counterFileName = 1;
        Find:
            if (File.Exists(_nameOfFile.ToString()))
            {
                FileInfo fileInfo1 = new FileInfo(_nameOfFile.ToString());
                if (fileInfo.Length > 30_000 && fileInfo1.Length > 30_000)
                {
                    _nameOfFile.Remove(115, 1);
                    counterFileName++;
                    _nameOfFile.Insert(115, counterFileName.ToString());
                    goto Find;
                }
                else
                {
                    using (StreamWriter streamWriter = File.AppendText(_nameOfFile.ToString()))
                    {
                        LogForDebug(logMessage, streamWriter);
                    }
                }
            }
            else
            {
                using (StreamWriter streamWriter = File.AppendText(_nameOfFile.ToString()))
                {
                    LogForDebug(logMessage, streamWriter);
                }
            }
        }

        internal void LogWriteInfo(string logMessage)
        {
            FileInfo fileInfo = new FileInfo(_nameOfFile.ToString());
            int counterFileName = 1;
        Find:
            if (File.Exists(_nameOfFile.ToString()))
            {
                FileInfo fileInfo1 = new FileInfo(_nameOfFile.ToString());
                if (fileInfo.Length > 30_000 && fileInfo1.Length > 30_000)
                {
                    _nameOfFile.Remove(115, 1);
                    counterFileName++;
                    _nameOfFile.Insert(115, counterFileName.ToString());
                    goto Find;
                }
                else
                {
                    using (StreamWriter streamWriter = File.AppendText(_nameOfFile.ToString()))
                    {
                        LogForInfo(logMessage, streamWriter);
                    }
                }
            }
            else
            {
                using (StreamWriter streamWriter = File.AppendText(_nameOfFile.ToString()))
                {
                    LogForInfo(logMessage, streamWriter);
                }
            }
        }

        internal void LogWriteError(string logMessage)
        {
            FileInfo fileInfo = new FileInfo(_nameOfFile.ToString());
            int counterFileName = 1;
        Find:
            if (File.Exists(_nameOfFile.ToString()))
            {
                FileInfo fileInfo1 = new FileInfo(_nameOfFile.ToString());
                if (fileInfo.Length > 30_000 && fileInfo1.Length > 30_000)
                {
                    _nameOfFile.Remove(115, 1);
                    counterFileName++;
                    _nameOfFile.Insert(115, counterFileName.ToString());
                    goto Find;
                }
                else
                {
                    using (StreamWriter streamWriter = File.AppendText(_nameOfFile.ToString()))
                    {
                        LogForError(logMessage, streamWriter);
                    }
                }
            }
            else
            {
                using (StreamWriter streamWriter = File.AppendText(_nameOfFile.ToString()))
                {
                    LogForError(logMessage, streamWriter);
                }
            }
        }

        void LogForDebug(string logMessage, TextWriter txtWriter)
        {
            txtWriter.Write("\r\n[Debug]: ");
            txtWriter.WriteLine("{0} {1}", DateTime.UtcNow.ToLongTimeString(),
                DateTime.UtcNow.ToLongDateString());
            txtWriter.WriteLine("  :{0}", logMessage);
            txtWriter.WriteLine("-------------------------------");
        }

        void LogForInfo(string logMessage, TextWriter txtWriter)
        { 
            txtWriter.Write("\r\n[Info]: ");
            txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            txtWriter.WriteLine("  :{0}", logMessage);
            txtWriter.WriteLine("-------------------------------");
        }

        void LogForError(string logMessage, TextWriter txtWriter)
        {
            txtWriter.Write("\r\n[Error]: ");
            txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            txtWriter.WriteLine("  :{0}", logMessage);
            txtWriter.WriteLine("-------------------------------");
        }
    }
}
