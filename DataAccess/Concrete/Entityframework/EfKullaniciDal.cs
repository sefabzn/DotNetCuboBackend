using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Entityframework.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Entityframework
{
    public class EfKullaniciDal : EfEntityRepositoryBase<Kullanici, CuboContext>, IKullaniciDal
    {
        public async Task<List<OperationClaim>> GetClaimsAsync(Kullanici kullanici)
        {
            using (var context = new CuboContext())
            {


                return  await( from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationId
                             where userOperationClaim.UserId == kullanici.ID
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name }).ToListAsync();

                
                

            }
        }
    }
}
