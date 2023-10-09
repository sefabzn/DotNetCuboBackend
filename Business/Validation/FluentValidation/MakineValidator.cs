using DataAccess.Concrete.Entityframework.Contexts;
using Entities.Concrete;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Business.Validation.FluentValidation
{
    public class MakineValidator : AbstractValidator<Makine>
    {
        public MakineValidator()
        {
            RuleFor(x => x.MakineIsmi).MinimumLength(2)
                .MustAsync(async (makineIsmi, cancellationToken) => !await CheckIfExistsAsync(makineIsmi))
                .WithMessage("A machine with this name already exists.");

            RuleFor(x => x.No).GreaterThan(0);

        }
        public async Task<bool> CheckIfExistsAsync(string makineIsmi)
        {
            using (var context = new CuboContext())
            {

                return await context.Makineler.AnyAsync(x => x.MakineIsmi == makineIsmi);

            }
        }
    }
}
