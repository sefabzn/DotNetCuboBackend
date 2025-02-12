using Business.Abstract;
using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;

public class DeliveryNoteManager : ManagerBase<SevkIrsaliye, IDeliveryNoteDal>, IDeliveryNoteService
{
    private  IKabloUretimService _kabloUretimService;
    private readonly IDeliveryNoteDal _deliveryNoteDal;
    private readonly ICustomerService _customerService;
    public DeliveryNoteManager(IDeliveryNoteDal deliveryNoteDal, IKabloUretimService kabloUretimService, ICustomerService customerService) : base(deliveryNoteDal)
    {
        _kabloUretimService = kabloUretimService;
        _deliveryNoteDal = deliveryNoteDal;
        _customerService = customerService;
    }

    public async Task<IResult> CreateDeliveryNoteAsync(SevkIrsaliye deliveryNote, List<SevkIrsaliyeKalem> items)
    {
        await _deliveryNoteDal.AddAsync(deliveryNote);
        //save items to database if the above operation is successful
        foreach (var item in items)
        {
            item.SevkIrsaliyeId = deliveryNote.Id;
            await _deliveryNoteDal.AddItemAsync(item);
        }
      
        return new SuccessResult("Delivery note created and stock updated.");
    }

   
    public async Task<IDataResult<List<SevkIrsaliye>>> GetAllWithItemsAndCustomerAsync()
    {
        var deliveryNotes = await _deliveryNoteDal.GetAllAsync();
        foreach (var note in deliveryNotes)
        {
            note.Kalemler = await _deliveryNoteDal.GetItemsByDeliveryNoteId(note.Id);

            note.Musteri = (await _customerService.GetAsync(x => x.Id == note.MusteriId)).Data;
        }
        return new SuccessDataResult<List<SevkIrsaliye>>(deliveryNotes);
    }
    public async Task<IResult> DeleteDeliveryNoteAsync(SevkIrsaliye deliveryNote)
    {
        var items = await _deliveryNoteDal.GetItemsByDeliveryNoteId(deliveryNote.Id);
        foreach (var item in items)
        {
            await _deliveryNoteDal.DeleteItemAsync(item);
        }
        await _deliveryNoteDal.DeleteAsync(deliveryNote);
        return new SuccessResult("Delivery note and its items deleted.");
    }
    public async Task<IResult> UpdateDeliveryNoteAsync(SevkIrsaliye deliveryNote, List<SevkIrsaliyeKalem> items)
    {
        await _deliveryNoteDal.UpdateAsync(deliveryNote);
        foreach (var item in items)
        {
            item.SevkIrsaliyeId = deliveryNote.Id;
            await _deliveryNoteDal.AddItemAsync(item);
        }
        return new SuccessResult("Delivery note updated.");
    }
    
    public async Task<IDataResult<SevkIrsaliye>> GetDeliveryNoteWithItemsByIdAsync(int deliveryNoteId)
    {
        var deliveryNote = await _deliveryNoteDal.GetAsync(d => d.Id == deliveryNoteId);
        if (deliveryNote != null)
        {
            deliveryNote.Kalemler = await _deliveryNoteDal.GetItemsByDeliveryNoteId(deliveryNoteId);
            return new SuccessDataResult<SevkIrsaliye>(deliveryNote);
        }
        return new ErrorDataResult<SevkIrsaliye>("Delivery note not found.");
    }
    public async Task<IResult> DeleteDeliveryNoteItemAsync(SevkIrsaliyeKalem item)
    {
        await _deliveryNoteDal.DeleteItemAsync(item);
        return new SuccessResult("Delivery note item deleted.");
    }

}
