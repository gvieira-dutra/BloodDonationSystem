using BloodDonationSystem.Application.Command.DonationCreate;
using FluentValidation;

namespace BloodDonationSystem.Application.Validators
{
    public class DonationCreateCommandValidator : AbstractValidator<DonationCreateCommand>
    {
        public DonationCreateCommandValidator()
        {
            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("ERROR. Description cannot be empty.")
                .NotNull().WithMessage("ERROR. Description cannot be empty.")
                .GreaterThan(420).WithMessage("ERROR. Valid donations must be greater than 420ml.")
                .LessThan(470).WithMessage("ERROR. Valid donations must be less than 470ml.");
        }
    }
}
