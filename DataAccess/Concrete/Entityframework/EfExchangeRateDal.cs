using DataAccess.Abstract;
using Entities.Concrete;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Entityframework
{
    public class EfExchangeRateDal : IExchangeRateDal
    {
        private const double POUNDtoKG = 0.453;

        public double GetCopperRate()
        {
            double copperDolarFiyati;
            var url = "https://www.marketwatch.com/investing/future/hg00";
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var node = doc.DocumentNode.SelectSingleNode("//*[@id='maincontent']/div[2]/div[3]/div/div[2]/h2/bg-quote");
            copperDolarFiyati = node != null ? Convert.ToDouble(node.InnerText.Replace('.', ',')) : 3;
            return copperDolarFiyati;
        }

        public double GetCopperRateByTL()
        {
            //decimal dolarKuru = GetDollarRate().Result;
            //double copperDolarFiyati = GetCopperRate();
            //copperDolarFiyati = (copperDolarFiyati / POUNDtoKG);
            //double copperTlFiyati = Convert.ToDouble(dolarKuru) * copperDolarFiyati;

            //return copperTlFiyati;
            return 15.00;
        }

        public async Task<decimal> GetDollarRate()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/latest/currencies/usd/try.json";
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    ExchangeRateData exchangeRate = JsonConvert.DeserializeObject<ExchangeRateData>(json);
                    return exchangeRate.Try;
                }
                else
                {
                    // Handle the error appropriately
                    throw new Exception("Failed to retrieve dollar rate.");
                }
            }
        }

        public async Task<decimal> GetEuroRate()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/latest/currencies/eur/try.json";
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    ExchangeRateData exchangeRate = JsonConvert.DeserializeObject<ExchangeRateData>(json);
                    return exchangeRate.Try;
                }
                else
                {
                    // Handle the error appropriately
                    throw new Exception("Failed to retrieve euro rate.");
                }
            }
        }

        public double GetPVCRate()
        {
            throw new NotImplementedException();
        }
    }
}
