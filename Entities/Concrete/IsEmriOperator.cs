using Entities.Base;

namespace Entities.Concrete
{
    public class IsEmriOperator
    {
        public int Id { get; set; }
        public int OperatorId { get; set; }
        public Operator Operator { get; set; }
        public int IsEmriId { get; set; }
        public IsEmriBase IsEmri { get; set; }
    }
}
