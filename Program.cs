using System;
using System.Diagnostics;
using System.Management;

namespace pmon
{
    class Program
    {
        static void monitID(int id)
        {
            try
            {
                Process p = Process.GetProcessById(id);
                Console.WriteLine("Process {0}\n  Process ID: {1}\n  Responding?: {2}\n  Handle: {3}\n  Start Time: {4}\n", p.ProcessName, p.Id, p.Responding, p.Handle, p.StartTime);
            }
            catch (Exception ex)
            {
                Console.WriteLine("the process may not exist.\nmore info: {0}", ex.Message);
            }
        }

        static void help()
        {
            Console.WriteLine("Available arguments and usage below");
            Console.WriteLine("pmon -a | shows all processes and process information");
            Console.WriteLine("pmon -id <pid> | shows process information by ID");
            Console.WriteLine("pmon -h | shows help");
        }
        static void allProcesses()
        {
            foreach (Process p in Process.GetProcesses())
            {
                try
                {
                    Console.WriteLine("Process Name: {0} | Process ID: {1} | Responding?: {2} | Handle: {3} | Start Time: {4}", p.ProcessName, p.Id, p.Responding, p.Handle, p.StartTime);
                } catch
                {

                }
            }
        }
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("pmon - a simple process monitor in C#");
                Console.WriteLine("Usage: pmon -h");
            }
            
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-h")
                {
                    help();
                } else if (args[i] == "-a")
                {
                    allProcesses();
                } else if (args[i] == "-id" && args[i+1] != null)
                {
                    monitID(int.Parse(args[i + 1]));
                }
            }
        }
    }
}
