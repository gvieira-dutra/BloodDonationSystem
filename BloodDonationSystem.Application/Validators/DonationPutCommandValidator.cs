using BloodDonationSystem.Application.Command.DonationPut;
using FluentValidation;

namespace BloodDonationSystem.Application.Validators
{
    public class DonationPutCommandValidator : AbstractValidator<DonationPutCommand>
    {
        public DonationPutCommandValidator()
        {
            RuleFor(x => x.NewQuantity)
                .NotEmpty().WithMessage("ERROR. Description cannot be empty.")
                .NotNull().WithMessage("ERROR. Description cannot be empty.")
                .GreaterThan(420).WithMessage("ERROR. Valid donations must be greater than 420ml.")
                .LessThan(470).WithMessage("ERROR. Valid donations must be less than 470ml.");

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ERROR. Id cannot be empty")
                .NotNull().WithMessage("ERROR. Id cannot be empty");
        }
    }
}
