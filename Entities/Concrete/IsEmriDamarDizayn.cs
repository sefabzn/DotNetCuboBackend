using Entities.Base;

namespace Entities.Concrete
{
    public class IsEmriDamarDizayn
    {
        public int Id { get; set; }
        public int IsEmriId { get; set; }
        public IsEmriBase? IsEmri { get; set; }
        public int DamarDizaynId { get; set; }
        public DamarDizaynBase? DamarDizayn { get; set; }

    }
}
