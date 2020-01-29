using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Linq;

namespace KursyWalut
{
    class DataFetcher
    {

        private List<DateTime> allDatesBetween;
        private List<string> allDatesBetweenStringified;
        private List<string> mainDocumentData;
        
        private string CurrentYearUrl
        {
            get => "http://www.nbp.pl/kursy/xml/dir.txt";
        }

        private string _OtherYeahUrl;

        private string OtherYeahUrl 
        { 
            get => _OtherYeahUrl; 
            set => _OtherYeahUrl = "http://www.nbp.pl/kursy/xml/dir" + value + ".txt"; 
        }

        private List<string> ReadMainFile()
        {
            HttpClient client = new HttpClient();
            mainDocumentData = new List<string>();
            mainDocumentData = client.GetStringAsync(CurrentYearUrl).Result.Split(Environment.NewLine).ToList();
            client.Dispose();
            return mainDocumentData;
        }
        private List<string> ReadMainFile(string year)
        {
            HttpClient client = new HttpClient();
            mainDocumentData = new List<string>();
            OtherYeahUrl = year;
            mainDocumentData = client.GetStringAsync(_OtherYeahUrl).Result.Split(Environment.NewLine).ToList();
            client.Dispose();
            return mainDocumentData;
        }

        private List<DateTime> GetDaysBetween(DateTime from, DateTime to)
        {
            if (to < from)
                throw new ArgumentException("Date to must be greater than or equal to start date");
            allDatesBetween = new List<DateTime>();
            allDatesBetween = Enumerable.Range(0, 1 + to.Subtract(from).Days)
                        .Select(offset => from.AddDays(offset))
                        .ToList();
            allDatesBetween.RemoveAll(i => i.DayOfWeek == DayOfWeek.Saturday || (i.DayOfWeek == DayOfWeek.Sunday));
            return allDatesBetween;
        }

        private List<string> StringifyDatesToCompare(List<DateTime> allDatesBetween)
        {
            allDatesBetweenStringified = new List<string>();
            foreach (var line in allDatesBetween)
            {
                allDatesBetweenStringified.Add(line.ToString("yyMMdd"));
            }
            return allDatesBetweenStringified;
        }

        private List<string> SearchForValidDocuments(List<string> dataFromDocument, List<string> listOfDaysBetween)
        {
            List<string> validDocumentsList = new List<string>();
            for (int i = 0; i < dataFromDocument.Count; i++)
            {
                if (dataFromDocument[i].StartsWith("c") && listOfDaysBetween.Contains(dataFromDocument[i].Substring(dataFromDocument[i].Length - 6)))
                {
                    validDocumentsList.Add(dataFromDocument[i]);
                }
            }
            if (validDocumentsList.Count == 0) throw new Exception("Didn't find any data from given interval");
            return validDocumentsList;
        }

        public List<string> GetListOfValidFiles(DateTime from, DateTime to)
        {
            List<string> listOfValidFiles = new List<string>();
            List<string> availableDates = StringifyDatesToCompare(GetDaysBetween(from, to));

            int yearTo = to.Year;
            int yearFrom = from.Year;

            int[] arrayOfGivenYears = new int[yearTo - yearFrom + 1];
            for (int i = 0; i < arrayOfGivenYears.Length; ++i)
                arrayOfGivenYears[i] = yearFrom + i;

            for (int i = 0; i < arrayOfGivenYears.Length; i++)
            {
                if (Int32.Parse(DateTime.Today.ToString("yyyy")) == arrayOfGivenYears[i])
                {
                    listOfValidFiles.AddRange(SearchForValidDocuments(ReadMainFile(), availableDates));
                }
                else
                {
                    listOfValidFiles.AddRange(SearchForValidDocuments(ReadMainFile(arrayOfGivenYears[i].ToString()),availableDates));
                }
            }

            return listOfValidFiles;
        }

    }
}
