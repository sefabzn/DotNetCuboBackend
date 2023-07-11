using DataAccess.Abstract;
using HtmlAgilityPack;
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
            double dolarKuru = GetDollarRate();
            double copperDolarFiyati = GetCopperRate();
            copperDolarFiyati = (copperDolarFiyati / POUNDtoKG);
            double copperTlFiyati = copperDolarFiyati * dolarKuru;

            return copperTlFiyati;


        }

        public double GetDollarRate()
        {
            //var url = "https://bigpara.hurriyet.com.tr/doviz";
            //var web = new HtmlWeb();
            //var doc = web.Load(url);
            //var node =doc.DocumentNode.SelectSingleNode("//*[@id='content']/div[2]/div/div[1]/a[1]/span[3]/span[2]");
            //double dolarKuru =Convert.ToDouble(node.InnerText);
            return 26.23;
        }

        public double GetEuroRate()
        {
            //var url = "https://bigpara.hurriyet.com.tr/doviz";
            //var web = new HtmlWeb();
            //var doc = web.Load(url);
            //var node = doc.DocumentNode.SelectSingleNode("//*[@id='content']/div[2]/div/div[1]/a[2]/span[3]/span[2]");
            //double euroKuru = Convert.ToDouble(node.InnerText);
            return 28.87;
        }

        public double GetPVCRate()
        {
            throw new NotImplementedException();
        }
    }
}
