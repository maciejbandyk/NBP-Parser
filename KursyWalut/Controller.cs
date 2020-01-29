using System;
using System.Collections.Generic;
using System.Text;

namespace KursyWalut
{
    public class Controller
    {

        private Validate validator;
        private DataFetcher datafetcher;
        private AppView view;
        private XMLreader xmlreader;
        List<double> listOfSellingRates;
        List<double> listOfBuyingRates;
        public string g { get; set; }
        public string f { get; set; }
        public enum ListType
        {
            BuyingRates = 0,
            SellingRates = 1
        }
        public Controller(string[] arguments)
        {
            validator = new Validate(arguments);
            datafetcher = new DataFetcher();
            view = new AppView();
            xmlreader = new XMLreader();
        }

        private bool ValidateArguments()
        {
            if (validator.IsCurrencyAvailable() && validator.IsDateCorrect() && validator.ArgumentsNumber())
                return true;
            return false;
        }

        public void Run(bool appSwitch)
        {
            if (ValidateArguments())
            {

                List<string> validFiles = datafetcher.GetListOfValidFiles(validator.GetDateFrom(), validator.GetDateTo());

                foreach (var line in validFiles)
                {
                    xmlreader.FetchXmlNodes(xmlreader.ReadDocument(line), validator.GetCurrency());
                }

                listOfBuyingRates = xmlreader.GetBuyingRatesList();
                listOfSellingRates = xmlreader.GetSellingRatesList();


                if (!appSwitch)
                {
                    view.PrintValues(ListType.BuyingRates, Statistics.GetMin(listOfBuyingRates), Statistics.GetMax(listOfBuyingRates), Statistics.GetAverage(listOfBuyingRates), Statistics.GetDeviation(listOfBuyingRates));
                    view.PrintValues(ListType.SellingRates, Statistics.GetMin(listOfSellingRates), Statistics.GetMax(listOfSellingRates), Statistics.GetAverage(listOfSellingRates), Statistics.GetDeviation(listOfSellingRates));
                }
                else
                {
                    g = ReturnBuyingListForWpf();
                    f = ReturnSellingListForWpf();
                }
            }
            else
            {
                view.IncorrectArguments();
            }

        }

        public void RunWPF()
        {
            Run(true);
        }
        private string ReturnBuyingListForWpf()
        {
            return view.PrintValuesForWpf(ListType.BuyingRates, Statistics.GetMin(listOfBuyingRates), Statistics.GetMax(listOfBuyingRates), Statistics.GetAverage(listOfBuyingRates), Statistics.GetDeviation(listOfBuyingRates));
        }

        private string ReturnSellingListForWpf()
        {
            return view.PrintValuesForWpf(ListType.SellingRates, Statistics.GetMin(listOfSellingRates), Statistics.GetMax(listOfSellingRates), Statistics.GetAverage(listOfSellingRates), Statistics.GetDeviation(listOfSellingRates));
        }

    }
}
