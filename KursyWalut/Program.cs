using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace KursyWalut
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Process.Start(@"..\..\..\..\KursyWalutWPF\bin\Debug\netcoreapp3.1\KursyWalutWPF.exe");
            }
            else
            {
                Controller controller = new Controller(args);
                controller.Run(false);
            }
        }
    }
}