using Core.DataAccess;
using Entities.Concrete;

public interface IDeliveryNoteDal : IEntityRepository<SevkIrsaliye>
{
    Task<List<SevkIrsaliyeKalem>> GetItemsByDeliveryNoteId(int deliveryNoteId);
    Task AddItemAsync(SevkIrsaliyeKalem item);
    Task DeleteItemAsync(SevkIrsaliyeKalem item);
}
