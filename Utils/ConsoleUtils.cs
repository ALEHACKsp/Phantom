using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phantom.Utils
{
    public static class ConsoleUtils
    {
        public static void SetTitle(string title) => Console.Title = title;

        public static void Log(string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("[Phantom] ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"({DateTime.Now.ToShortTimeString()}) ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(text + "\n");
        }
    }
}
