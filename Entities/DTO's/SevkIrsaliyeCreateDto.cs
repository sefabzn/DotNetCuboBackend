using Entities.Concrete;


namespace Entities.DTO_s
{
    public class SevkIrsaliyeCreateDto
    {
        public SevkIrsaliye? DeliveryNote { get; set; }
        public List<SevkIrsaliyeKalem>? Items { get; set; }
    }

}
