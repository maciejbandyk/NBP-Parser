using System;
using System.Collections.Generic;
using System.Text;

namespace KursyWalut
{
    public class Values
    {
        public Values(string listType, string currency, double min, double max, double average, double standardDeviation)
        {
            Type = listType;
            Currency = currency;
            Min = min;
            Max = max;
            Average = average;
            StandardDeviation = standardDeviation;
        }

        public string Type { get; set; }
        public string Currency { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Average { get; set; }
        public double StandardDeviation { get; set; }
    }
}