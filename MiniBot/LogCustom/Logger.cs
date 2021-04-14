using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace LogCustom
{
    public sealed class Logger
    {
        public static void Debug(string messageTemplate) 
        {
            LogWriter logWriter = new LogWriter();
            logWriter.LogWriteDebug(messageTemplate);
        }
        public static void Info(string messageTemplate)
        {
            LogWriter logWriter = new LogWriter();
            logWriter.LogWriteInfo(messageTemplate);
        }
        public static void Error(string messageTemplate)
        {
            LogWriter logWriter = new LogWriter();
            logWriter.LogWriteError(messageTemplate);
        }
    }
}
