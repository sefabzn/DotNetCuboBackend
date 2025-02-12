using Core.DataAccess.EntityFramework;
using DataAccess.Concrete.Entityframework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

public class EfDeliveryNoteDal : EfEntityRepositoryBase<SevkIrsaliye, CuboContext>, IDeliveryNoteDal
{
    public async Task<List<SevkIrsaliyeKalem>> GetItemsByDeliveryNoteId(int deliveryNoteId)
    {
        using (var context = new CuboContext())
        {
            return await context.SevkIrsaliyeKalemler.Where(i => i.SevkIrsaliyeId == deliveryNoteId).ToListAsync();
        }
    }
    public async Task AddItemAsync(SevkIrsaliyeKalem item)
    {
        using (var context = new CuboContext())
        {
            context.SevkIrsaliyeKalemler.Add(item);
            await context.SaveChangesAsync();
        }
    }
    public async Task DeleteItemAsync(SevkIrsaliyeKalem item)
    {
        using (var context = new CuboContext())
        {
            context.SevkIrsaliyeKalemler.Remove(item);
            await context.SaveChangesAsync();
        }
    }
}
