using System;

namespace RR.GRM.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var finder =  IoC.Container.GetInstance<IConsoleAssetFinder>();
            while (true)
            {
                var arg = System.Console.ReadLine();

                if (arg == "exit")
                {
                    break;
                }

                finder.Print(arg);
            }
        }
    }
}
