using DataAccess.Abstract;
using Entities.Concrete;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Entityframework
{
    public class EfExchangeRateDal : IExchangeRateDal
    {
        double POUNDtoKG = 0.453;
        public double GetCopperRate()
        {
            double copperDolarFiyati;
           
            
            var url = "https://www.marketwatch.com/investing/future/hg00";
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var node = doc.DocumentNode.SelectSingleNode("//*[@id='maincontent']/div[2]/div[3]/div/div[2]/h2/bg-quote");
            copperDolarFiyati = node!=null?Convert.ToDouble(node.InnerText.Replace('.', ',')):3;
            return copperDolarFiyati;
        }

        public double GetCopperRateByTL()
        {
            decimal dolarKuru = GetDollarRate().Result;
            double copperDolarFiyati = GetCopperRate();
            copperDolarFiyati = (copperDolarFiyati / POUNDtoKG);
            double copperTlFiyati = Convert.ToDouble(dolarKuru) * copperDolarFiyati;

            return copperTlFiyati;


        }

        public async Task<decimal>GetDollarRate()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/latest/currencies/usd/try.json"; // Değiştirilmesi gereken URL
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    ExchangeRateData exchangeRate = JsonConvert.DeserializeObject<ExchangeRateData>(json);
                    return exchangeRate.Try;
                }
                else
                {
                    // İstek başarısız olduysa hata işlemleri yapabilirsiniz.
                    return 0;
                }
            }
        }

        public async Task<decimal> GetEuroRate()
        {


            using (HttpClient client = new HttpClient())
            {
                string url = "https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/latest/currencies/eur/try.json"; // Değiştirilmesi gereken URL
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    ExchangeRateData exchangeRate = JsonConvert.DeserializeObject<ExchangeRateData>(json);
                    return exchangeRate.Try;
                }
                else
                {
                    // İstek başarısız olduysa hata işlemleri yapabilirsiniz.
                    return 0;
                }
            }
          
        }

        public double GetPVCRate()
        {
            throw new NotImplementedException();
        }
    }
}
