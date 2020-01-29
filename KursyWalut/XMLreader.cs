using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml;

namespace KursyWalut
{
    class XMLreader
    {
        private string XmlString { get; set; }
        private List<double> buyingRate = new List<double>();
        private List<double> sellingRate = new List<double>();

        private string UrlBuilder(string text)
        {
            string validUrl = "http://www.nbp.pl/kursy/xml/" + text + ".xml";
            return validUrl;
        }

        public XmlDocument ReadDocument(string url)
        {
            using (var wc = new WebClient())
            {
                XmlString = wc.DownloadString(UrlBuilder(url));
            }
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(XmlString);
            return xmlDocument;
        }

        public void FetchXmlNodes(XmlDocument document, string currency)
        {
            XmlNodeList xnList = document.SelectNodes("/tabela_kursow/pozycja");
            foreach (XmlNode node in xnList)
            {
                
                if (node["kod_waluty"].InnerText==currency)
                {
                    buyingRate.Add(Double.Parse(node["kurs_kupna"].InnerText));   
                    sellingRate.Add(Double.Parse(node["kurs_sprzedazy"].InnerText));
                }
                
            }
        }

        public List<double> GetBuyingRatesList()
        {
            return buyingRate;
        }

        public List<double> GetSellingRatesList()
        {
            return sellingRate;
        }
    }
}
