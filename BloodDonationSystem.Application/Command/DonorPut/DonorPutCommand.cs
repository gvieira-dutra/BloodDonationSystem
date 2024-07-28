using BloodDonationSystem.Application.ViewModels;
using BloodDonationSystem.Core.Enum;
using MediatR;

namespace BloodDonationSystem.Application.Command.DonorPut
{
    public class DonorPutCommand(int id, string fullName, string email, DateTime doB, string gender, double weight, BloodTypeEnum bloodType, RhFactorEnum rhFactor) : IRequest<DonorViewModel>
    {
        public int Id { get; set; } = id;
        public string FullName { get; private set; } = fullName;
        public string Email { get; private set; } = email;
        public DateTime DoB { get; private set; } = doB;
        public string Gender { get; private set; } = gender;
        public double Weight { get; private set; } = weight;
        public BloodTypeEnum BloodType { get; private set; } = bloodType;
        public RhFactorEnum RhFactor { get; private set; } = rhFactor;
    }
}
