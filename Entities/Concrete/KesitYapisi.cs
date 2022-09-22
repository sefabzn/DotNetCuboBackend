using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class KesitYapisi : IEntity

    {
        public int Id { get; set; }
        public double KesitCapi { get; set; }
        public double Back{ get; set; }
        public double DisCap{ get; set; }
        public double Ayna{ get; set; }
        public int KilcalDamarSayisi{ get; set; }
        public double KilcalDamarCapi{ get; set; }
        public double Hatve{ get; set; }
        public double Alan{ get; set; }
        public double Coef{ get; set; }
    }
}
