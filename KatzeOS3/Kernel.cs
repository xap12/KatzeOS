using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Sys = Cosmos.System;
using System.IO;
using System.Reflection.Metadata;
using System.ComponentModel.Design;
using Cosmos.HAL.BlockDevice.Registers;

namespace KatzosT
{
    public class Kernel : Sys.Kernel
    {
        public string OSVER { get; set; } = "0.0.2";

        Sys.FileSystem.CosmosVFS fs;
        string main_directory = (@"0:\");
        string current_directory = (@"0:\");
        string last_directory = (@"0:\");

        protected override void BeforeRun()
        {
            Sys.FileSystem.CosmosVFS fs = new Cosmos.System.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);

            Console.Clear();
            startupo.banner();
            Console.WriteLine("0.0.2, booted up at " + DateTime.Now);
        }

        protected override void Run()
        {
            Console.Write(">>>");
            var input = Console.ReadLine().ToLower();
            //reprogramming
            if (input == "")
            { return; }

            else if (input == "help")
            { commands.help(); }
            else if (input == "help_sp")
            { commands.help_sp(); }
            else if (input == "cls")
            { commands.cls(); }
            else if (input == "time")
            { commands.time(); }
            else if (input == "ver")
            { commands.ver(); }
            else if (input == "reboot")
            { commands.reboot(); }
            else if (input == "halt")
            { commands.halt(); }


            // dir command
            else if (input == "dir")
            {
                var files_list = Directory.GetFiles(current_directory);
                var directory_list = Directory.GetDirectories(current_directory);

                foreach (var file in files_list)
                {
                    Console.WriteLine(file);
                }
                foreach (var directory in directory_list)
                {
                    Console.WriteLine(directory);
                }
            }
            //end of dir command

            //mkdir cmd
            else if (input.ToLower().StartsWith("mkdir "))
            {
                string dirin = input.Remove(0, 6);
                try
                {
                    Directory.CreateDirectory(current_directory + dirin);
                    Console.WriteLine("the dir has been created.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            //end of mkdir cmd

            //dedir cmd
            else if (input.ToLower().StartsWith("dedir "))
            {
                string dirde = input.Remove(0, 6);
                try
                {
                    Directory.Delete(current_directory + dirde);
                    Console.WriteLine("the dir has been removed.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                //end of dedir cmd
            }

            //mkfi cmd
            else if (input.ToLower().StartsWith("mkfi "))
            {
                string mkfin = input.Remove(0, 5);


                try
                {
                    var file_stream = File.Create(current_directory + mkfin);
                    Console.WriteLine("the file has been created.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            //end of mkfi cmd

            //defi cmd
            else if (input.ToLower().StartsWith("defi "))
            {
                string defilin = input.Remove(0, 5);
                try
                {
                    File.Delete(current_directory + defilin);
                    Console.WriteLine("the file has been removed.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }


            }
            //end of defi cmd

            //wrfi cmd
            else if (input.ToLower().StartsWith("wrfi "))
            {
                string wrfiin = input.Remove(0, 5);
                Console.WriteLine(">> new file content>");
                string fileincon = Console.ReadLine();
                try
                {
                    File.WriteAllText((current_directory + wrfiin), fileincon);
                    Console.WriteLine("new file content: \n");
                    Console.WriteLine(File.ReadAllText(current_directory + wrfiin));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            //end of wrfi cmd

            //rdfi cmd
            else if (input.ToLower().StartsWith("rdfi "))
            {
                string rdfiin = input.Remove(0, 5);

                try
                {
                    Console.WriteLine(rdfiin + " contents are: \n");
                    Console.WriteLine(File.ReadAllText(current_directory + rdfiin));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }//end of rdfi cmd

            //change_dir cmd
            else if (input.ToLower().StartsWith("cd "))
            {
                string cdiin = input.Remove(0, 3);
                if (cdiin == "...")
                {
                    try
                    {
                        current_directory = main_directory;
                        Console.WriteLine(current_directory + "\n");
                    }
                    catch
                    {
                        Console.WriteLine("something is wrong. \n");
                    }
                }
                // no last dir can be used
                else if (cdiin == "..")
                {
                    Console.WriteLine("something is wrong.");
                }
                else { 

                try
                {
                    current_directory = current_directory + cdiin;
                    Console.WriteLine("\n");
                    Console.WriteLine(current_directory + "\n");
                }
                catch
                {
                    Console.WriteLine("s.omething is wrong. \n");
                }
                }

            }
            // end of change_dir cmd












            //invalidin cmd
            else { commands.invalidin(); }
            }
        }
    }


