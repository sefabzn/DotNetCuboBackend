using Entities.Base;

namespace Entities.Concrete
{
    public class Operator
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public List<IsEmriBase>? IsEmriBases { get; set; }
        public int MakineId { get; set; }
        public Makine? Makine { get; set; }


    }
}
