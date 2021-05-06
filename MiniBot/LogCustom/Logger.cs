using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace LogCustom
{
    public sealed class Logger
    {
        public static void Debug(string messageTemplate)
        {
            var methodInfo = new StackFrame(1).GetMethod();
            Thread thread = Thread.CurrentThread;
            LogWriter logWriter = new LogWriter();
            logWriter.LogWriteDebug($"Thread: Priority: {thread.Priority}, Id: {thread.ManagedThreadId}, Background: {thread.IsBackground}, " +
                $"Pool: {thread.IsThreadPoolThread}, State: {thread.ThreadState}."
                + $"\nLocation: Namespace: {methodInfo.ReflectedType.FullName}." +
                $" Method: {methodInfo.Name}." + $"\nMessage: {messageTemplate}");
        }

        public static void Info(string messageTemplate)
        {
            var methodInfo = new StackFrame(1).GetMethod();
            Thread thread = Thread.CurrentThread;

            Type logWriter = typeof(LogWriter);
            ConstructorInfo ctor = logWriter.GetTypeInfo().DeclaredConstructors.FirstOrDefault();
            object[] args = new object[] { };
            object obj = ctor.Invoke(args);
            MethodInfo methodLogWriteInfo = obj.GetType().GetTypeInfo().GetDeclaredMethod("LogWriteInfo");
            string resultLogString = $"Thread: Priority: {thread.Priority}, Id: {thread.ManagedThreadId}, Background: {thread.IsBackground}, " +
               $"Pool: {thread.IsThreadPoolThread}, State: {thread.ThreadState}."
               + $"\nLocation: Namespace: {methodInfo.ReflectedType.FullName}." +
               $" Method: {methodInfo.Name}." + $"\nMessage: {messageTemplate}";

            var methodResult = methodLogWriteInfo.Invoke(obj, new object[] { resultLogString });
        }

        public static void Error(string messageTemplate)
        {
            var methodInfo = new StackFrame(1).GetMethod();
            Thread thread = Thread.CurrentThread;
            LogWriter logWriter = new LogWriter();
            logWriter.LogWriteError($"Thread: Priority: {thread.Priority}, Id: {thread.ManagedThreadId}, Background: {thread.IsBackground}, " +
                $"Pool: {thread.IsThreadPoolThread}, State: {thread.ThreadState}."
                + $"\nLocation: Namespace: {methodInfo.ReflectedType.FullName}." +
                $" Method: {methodInfo.Name}." + $"\nMessage: {messageTemplate}");
        }
    }
}
