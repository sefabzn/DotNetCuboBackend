using Core.Entities;
using Entities.Base;

namespace Entities.Concrete
{
    public class Barkod : IEntity
    {

        public int Id { get; set; }
        public string? BarkodString { get; set; } = "No Barcode";
        public int? IsEmriId { get; set; }
        public IsEmriBase? IsEmri { get; set; }
    }
}
