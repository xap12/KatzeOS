using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatzosT
{
    public class commands
    {
        public static void help()
        {
            Console.WriteLine(@"help's first page

help - gives you help in commands
help_sp for the help's second page

cls - clears the shell

time - displays the time

dir - displays directories.

cd directory_name - changes current directory to 
    another directory in current directory.
cd ... - changes current directory to the main directory 

mkdir directory_name - creates a directory with a name

dedir directory_name - removes a directory
");
        }
        public static void help_sp()

            {
                Console.WriteLine(@"help's second page

mkfi file_name - creates a file with a name

wrfi file_name - writes new data into an existing file.

rdfi file_name - reads data from an existing file.

ver - displays the current version of KatzeOS

reboot - reboots the OS

halt - halts the OS
");
            }
        public static void cls() { Console.Clear(); }
        public static void time() { Console.WriteLine(DateTime.Now); }
        public static void reboot() { Cosmos.System.Power.Reboot(); }
        public static void halt() { Cosmos.System.Power.Shutdown(); }
        public static void ver() { Console.WriteLine(":KatzeOS alpha2 _ 0.0.2"); }
        public static void invalidin() { Console.WriteLine("Invalid input. Try >>>help"); }


    }

}
