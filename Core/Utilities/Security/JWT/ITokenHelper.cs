using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {

        AccessToken CreateToken(Kullanici kullanici, List<OperationClaim> operationClaims); 
    }
}
