using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class OrderProcess:IEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProcessId { get; set; }

        public bool isCompleted { get; set; }
        public string Barcode { get; set; }
    }
}
