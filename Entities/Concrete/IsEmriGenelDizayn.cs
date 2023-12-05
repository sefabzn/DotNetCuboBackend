using Entities.Base;

namespace Entities.Concrete
{
    public class IsEmriGenelDizayn
    {
        public int Id { get; set; }
        public int IsEmriId { get; set; }
        public IsEmriBase? IsEmri { get; set; }
        public int GenelDizaynId { get; set; }
        public GenelDizaynBase? GenelDizayn { get; set; }

    }
}
