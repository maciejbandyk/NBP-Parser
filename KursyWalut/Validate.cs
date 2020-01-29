using System;
using System.Collections.Generic;
using System.Text;

namespace KursyWalut
{
    class Validate
    {
        private string[] _arguments;
        private DateTime dateFrom;
        private DateTime dateTo;
        public Validate(string[] arguments)
        {
            _arguments = arguments;
        }
        public enum Currencies
        {
            USD,
            EUR,
            CHF,
            GBP
        }

        public bool ArgumentsNumber()
        {
            if (_arguments.Length < 3)
            {
                throw new Exception("Please give all 3 arguments");
                //return false;
            }
            return true;
        }
        public bool IsCurrencyAvailable()
        {
            if (Enum.IsDefined(typeof(Currencies), _arguments[0]))
            {
                return true;
            }
            throw new Exception("Your currency is not available for the moment. We accept only EUR, USD, CHF and GBP");
            /*
            Console.WriteLine("Zmienne które są akceptowalne to tylko EUR, USD, CHF, GBP!");
            return false;
            */
        }

        public bool IsDateCorrect()
        {

            try
            {
                dateFrom = DateTime.Parse(_arguments[1]);
                dateTo = DateTime.Parse(_arguments[2]);
            }
            catch (FormatException)
            {
                Console.WriteLine("Drugi i trzeci argument muszą zawierać poprawne daty w formacie DD-MM-YYYY");
                return false;
            }
            
            return true;
        }

        public string GetCurrency()
        {
            return _arguments[0];
        }

        public DateTime GetDateFrom()
        {
            return dateFrom;
        }

        public DateTime GetDateTo()
        {
            return dateTo;
        }


    }
}
