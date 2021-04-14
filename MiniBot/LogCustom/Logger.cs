using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace LogCustom
{
    public sealed class Logger
    {
        public static void Debug(string messageTemplate) 
        {
            var methodInfo = new StackFrame(1).GetMethod();
            LogWriter logWriter = new LogWriter();
            logWriter.LogWriteDebug($"Namespace: {methodInfo.ReflectedType.FullName}. Method: {methodInfo.Name}.\n" + $"Message: {messageTemplate}");
        }

        public static void Info(string messageTemplate)
        {
            var methodInfo = new StackFrame(1).GetMethod();
            LogWriter logWriter = new LogWriter();
            logWriter.LogWriteInfo($"Namespace: {methodInfo.ReflectedType.FullName}. Method: {methodInfo.Name}.\n" + $"Message: {messageTemplate}");
        }

        public static void Error(string messageTemplate)
        {
            var methodInfo = new StackFrame(1).GetMethod();
            LogWriter logWriter = new LogWriter();
            logWriter.LogWriteError($"Namespace: {methodInfo.ReflectedType.FullName}. Method: {methodInfo.Name}.\n" + $"Message: {messageTemplate}");
        }
    }
}
