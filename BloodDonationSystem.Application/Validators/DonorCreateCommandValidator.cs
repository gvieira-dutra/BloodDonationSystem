using BloodDonationSystem.Application.Command.DonorCreate;
using BloodDonationSystem.Infrastructure.Persistence;
using FluentValidation;

namespace BloodDonationSystem.Application.Validators
{
    public class DonorCreateCommandValidator : AbstractValidator<DonorCreateCommand>
    {
        private readonly BloodDonationDbContext _dbContext;
        public DonorCreateCommandValidator(BloodDonationDbContext
            dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.FullName)
                .NotNull().WithMessage("ERROR! Name cannot be empty")
                .NotEmpty().WithMessage("ERROR! Name cannot be empty")
                .MaximumLength(150).WithMessage("ERROR! Name must have less than 150 characters.");

            RuleFor(x => x.Email)
                .NotNull().WithMessage("ERROR! Email cannot be empty")
                .NotEmpty().WithMessage("ERROR! Email cannot be empty")
                .EmailAddress().WithMessage("ERROR! This email format is not valid.")
                .Must(BeUniqueEmail).WithMessage("ERROR! Email already registered.");

            RuleFor(x => x.DoB)
                .NotNull().WithMessage("ERROR! Name cannot be empty")
                .NotEmpty().WithMessage("ERROR! Name cannot be empty");

            RuleFor(x => x.Gender)
                .NotNull().WithMessage("ERROR! Gender cannot be empty")
                .NotEmpty().WithMessage("ERROR! Gender cannot be empty")
                .Must(g => 
                string.Equals(g, "male", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(g, "female", StringComparison.OrdinalIgnoreCase
                ))
                .WithMessage("ERROR! Gender must be 'male' or 'female'.");

            RuleFor(x => x.Weight)
                .NotNull().WithMessage("ERROR! Weight cannot be empty")
                .NotEmpty().WithMessage("ERROR! Weight cannot be empty")
                .GreaterThan(10).WithMessage("ERROR! Must have at least 10lb to register.");
        }
        private bool BeUniqueEmail(string email)
        {
            return !_dbContext.Donors.Any(u => u.Email == email);
        }
    }
}
