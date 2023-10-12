using Core.Entities;
using Entities.Base;

namespace Entities.Concrete
{
    public class Process : IEntity
    {
        public int Id { get; set; }
        public string? Isim { get; set; }
        public string? Aciklama { get; set; }
        public int Order { get; set; }
        public int IsEmriId { get; set; }
        public IsEmriBase? IsEmri { get; set; }
        public bool TamamlanmaDurumu { get; set; } = false;
    }
}
