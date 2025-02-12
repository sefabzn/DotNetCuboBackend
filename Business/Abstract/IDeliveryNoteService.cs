using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;

public interface IDeliveryNoteService : IServiceRepository<SevkIrsaliye>
{
    Task<IResult> CreateDeliveryNoteAsync(SevkIrsaliye deliveryNote, List<SevkIrsaliyeKalem> items);
    Task<IDataResult<List<SevkIrsaliye>>> GetAllWithItemsAndCustomerAsync();
    Task<IResult> DeleteDeliveryNoteAsync(SevkIrsaliye deliveryNote);
    Task<IResult> UpdateDeliveryNoteAsync(SevkIrsaliye deliveryNote, List<SevkIrsaliyeKalem> items);
    Task<IDataResult<SevkIrsaliye>> GetDeliveryNoteWithItemsByIdAsync(int deliveryNoteId);
    Task<IResult> DeleteDeliveryNoteItemAsync(SevkIrsaliyeKalem item);
}
