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
    }
}
