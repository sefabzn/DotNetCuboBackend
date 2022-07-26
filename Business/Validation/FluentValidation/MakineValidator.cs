using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.Validation.FluentValidation
{
    public class MakineValidator:AbstractValidator<Makine>
    {
        public MakineValidator()
        {
            RuleFor(x => x.MakineIsmi).MinimumLength(2);
            RuleFor(x => x.No).GreaterThan(0);

        }
    }
}
