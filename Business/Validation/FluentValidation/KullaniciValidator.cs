using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using FluentValidation;

namespace Business.Validation.FluentValidation
{
    public class KullaniciValidator : AbstractValidator<Kullanici>
    {
        public KullaniciValidator()
        {
            RuleFor(x => x.Kullanici_Adi).MinimumLength(2);
            RuleFor(x => x.Kullanici_Adi).NotEmpty();

        }
    }
}
