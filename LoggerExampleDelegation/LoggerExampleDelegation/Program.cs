using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerExampleDelegation
{
    public class Logger {
        public delegate void LogAction(string message);
        private LogAction _logAction;
        public Logger(LogAction logAction)
        {
            _logAction = logAction;
        }
        public void log(string message)
        {
            _logAction(message);
        }
    }

    internal class Program
    {
        public static void LogToScreen(string message)
        {
            Console.WriteLine(message);
        }
        public static void LogToFile(string message)
        {
            string File = "Log.txt";
            using(StreamWriter writer=new StreamWriter(File, true))
            {
                writer.WriteLine(message);
            }
        }
        static void Main(string[] args)
        {
            Logger loggertoScreen = new Logger(LogToScreen);
            Logger LoggerToFile = new Logger(LogToFile);
            loggertoScreen.log("hello world!");
            LoggerToFile.log("Here Login");
        }
    }
}
