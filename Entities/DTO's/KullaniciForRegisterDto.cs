using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTO_s
{
    public class KullaniciForRegisterDto:IDto
    {
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
    }
}
