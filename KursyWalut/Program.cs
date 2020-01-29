using System;
using System.Collections.Generic;
using System.Linq;

namespace KursyWalut
{
    class Program
    {
        static void Main(string[] args)
        {

            Controller controller = new Controller(args);
            controller.Run(false);

        }
    }
}