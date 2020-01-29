using System;
using System.Collections.Generic;
using System.Text;
using static KursyWalut.Controller;

namespace KursyWalut
{
    class AppView
    {
        public void IncorrectArguments()
        {
            throw new Exception("Arguments are invalid.");
        }

        public void PrintValues(ListType list, double min, double max, double average, double deviation)
        {
            if (list == 0)
            {
                Console.WriteLine("Buying rate list. Min value: {0}, Max value: {1}, Average: {2}, Standard deviation: {3}", min, max, average, deviation);
            }
            else
            {
                Console.WriteLine("Sellnig rate list. Min value: {0}, Max value: {1}, Average: {2}, Standard deviation: {3}", min, max, average, deviation);
            }

        }

        public string PrintValuesForWpf(ListType list, double min, double max, double average, double deviation)
        {
            if (list == 0)
            {
                string brl = "Buying rate list. Min value: " + min + ", Max value: + " + max + ", Average: " + average + ", Standard deviation: " + deviation;
                return brl;
            }
            else
            {
                string srl = "Selling rate list. Min value: " + min + ", Max value: + " + max + ", Average: " + average + ", Standard deviation: " + deviation;
                return srl;
            }

        }
    }
}
