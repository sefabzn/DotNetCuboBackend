using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Base
{
    public class GenelDizaynBase:IEntity
    {
        public int Id { get; set; }
        public string Kablo { get; set; }
        public double Kesit { get; set; }
        public double Orgu { get; set; }
        public string OrguTelYapisi { get; set; }
        public double PolyesterOlcusu { get; set; }
        public string FolyoTipi { get; set; }
        public double FolyoOlcusu { get; set; }
        public double DisKilif { get; set; }
        public double DisCap { get; set; }
        public double Back { get; set; }
        public double Ayna { get; set; }
        public string Kalip { get; set; }
        public DateTime Tarih { get; set; }
        public int DamarSayisi { get; set; }
        public int GirilenDamarSayisi { get; set; }
        public string Zorlama { get; set; }
        public DateTime DegistirilmeTarihi { get; set; }
        public string Degistiren { get; set; }
    }
}
