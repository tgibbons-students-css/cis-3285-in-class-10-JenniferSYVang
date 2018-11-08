using CurrencyTrader;
using CurrencyTrader.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CurrencyTrader
{
    public class AdjustTradeDataProvider : ITradeDataProvider
    {
        private readonly String url;
        ITradeDataProvider urlProvider;

        public AdjustTradeDataProvider(String url)
        {
            this.url = url;
            urlProvider = new UrlTradeDataProvider(url);
        }

        public IEnumerable<string> GetTradeData()
        {
            var tradeData = new List<String>();
            IEnumerable<string> inTradeData = urlProvider.GetTradeData();

            foreach(string line in inTradeData)
            {
                if (line.Contains("GBP"))
                {
                    tradeData.Add(line.Replace("GBP", "EUR"));
                }
                else
                {
                    tradeData.Add(line);
                }
                
            }
            return tradeData;
        }
    }
}
