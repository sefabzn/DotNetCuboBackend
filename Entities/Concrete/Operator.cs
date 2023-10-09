using Entities.Base;

namespace Entities.Concrete
{
    public class Operator
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public List<IsEmriBase>? IsEmirleri { get; set; }


    }
}
