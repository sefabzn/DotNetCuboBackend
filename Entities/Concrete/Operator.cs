using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Operator
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public List<OperatorIsEmri>? IsEmirleri{ get; set; }


    }
}
