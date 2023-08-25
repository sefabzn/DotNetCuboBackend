using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Process:IEntity
    {
        public int Id{ get; set; }
        public string? Isim{ get; set; }
        public string? Aciklama{ get; set; }
        public int Order { get; set; }
        public int IsEmriId { get; set; }
        public OperatorIsEmri? OperatorIsEmri{ get; set; }
        public bool TamamlanmaDurumu { get; set; } = false;
    }
}
