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
        public double GetDollarRate()
        {
            var url = "https://bigpara.hurriyet.com.tr/doviz";
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var node =doc.DocumentNode.SelectSingleNode("//*[@id='content']/div[2]/div/div[1]/a[1]/span[3]/span[2]");
            double dolarKuru =Convert.ToDouble(node.InnerText);
            return dolarKuru;
        }

        public double GetEuroRate()
        {
            var url = "https://bigpara.hurriyet.com.tr/doviz";
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var node = doc.DocumentNode.SelectSingleNode("//*[@id='content']/div[2]/div/div[1]/a[2]/span[3]/span[2]");
            double euroKuru = Convert.ToDouble(node.InnerText);
            return euroKuru;
        }
    }
}
