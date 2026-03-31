using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace EventLog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string SourceName = "MyApp";
            if (!System.Diagnostics.EventLog.SourceExists(SourceName))
            {
                System.Diagnostics.EventLog.CreateEventSource(SourceName, "Application");
                Console.WriteLine("Event source created.");
            }
            System.Diagnostics.EventLog.WriteEntry(SourceName, "This is an information event.", EventLogEntryType.Information);
            System.Diagnostics.EventLog.WriteEntry(SourceName, "This is an error event.", EventLogEntryType.Error);
            System.Diagnostics.EventLog.WriteEntry(SourceName, "This is an warning event.", EventLogEntryType.Warning);
        }
    }
}
