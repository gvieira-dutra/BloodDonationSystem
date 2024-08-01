namespace BloodDonationSystem.Core.DTO
{
    public class DonorDTO(int id, string fullName, string email, string gender, string bloodType, string rhFactor)
    {
        public int Id { get; private set; } = id;
        public string FullName { get; private set; } = fullName;
        public string Email { get; private set; } = email;
        public string Gender { get; private set; } = gender;
        public string BloodType { get; private set; } = bloodType;
        public string RhFactor { get; private set; } = rhFactor;

    }
}
