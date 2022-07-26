using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.Validation.FluentValidation
{
    public class KabloUretimValidator:AbstractValidator<KabloUretim>
    {
        public KabloUretimValidator()
        {
            RuleFor(x => x.KabloIsmi).MinimumLength(2);
        }
    }
}
