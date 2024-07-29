using BloodDonationSystem.Core.Enum;

namespace BloodDonationSystem.Core.DTO
{
    public class DonorDTO(int id, string fullName, string email, string gender, BloodTypeEnum bloodType, RhFactorEnum rhFactor)
    {
        public int Id { get; private set; } = id;
        public string FullName { get; private set; } = fullName;
        public string Email { get; private set; } = email;
        public string Gender { get; private set; } = gender;
        public BloodTypeEnum BloodType { get; private set; } = bloodType;
        public RhFactorEnum RhFactor { get; private set; } = rhFactor;

    }
}
