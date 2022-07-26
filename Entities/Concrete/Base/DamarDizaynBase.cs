using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Base
{
    public class DamarDizaynBase:IEntity
    {
        public int Id { get; set; }
        public int AnaId { get; set; }
        public int DamarNo { get; set; }
        public string Renk { get; set; }
        public double Kesit { get; set; }
        public double Etk { get; set; }
        public double Cap { get; set; }
        public double Back { get; set; }
        public double Ayna { get; set; }
        public string Kalip { get; set; }
        public double Hatve { get; set; }
    }
}
