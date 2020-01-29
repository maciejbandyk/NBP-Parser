using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KursyWalut
{
    static class Statistics
    {
        public static double GetAverage(List<double> list) 
        {

            return Math.Round(list.Sum() / list.Count,4) ;
        }

        public static double GetMin(List<double> list) 
        {
            return list.Min();
        }
        public static double GetMax(List<double> list) 
        {
            return list.Max();
        }
        public static double GetDeviation(List<double> list) 
        {
            double avg = list.Average();
            double sum = list.Sum(v => (v - avg) * (v - avg));
            double denominator = list.Count - 1;
            return denominator > 0.0 ? Math.Round(Math.Sqrt(sum / denominator),8) : -1;
        }

    }
}
