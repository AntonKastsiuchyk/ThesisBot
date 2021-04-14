using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MiniBot.Activity
{
    class Support
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetInfoLog()
        {
            var method = new StackFrame(1).GetMethod();
            return $"Namespace: {method.ReflectedType.FullName}. Method: {method.Name}";
        }
    }
}
