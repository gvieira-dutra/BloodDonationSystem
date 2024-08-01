namespace BloodDonationSystem.Core.DTO
{

    public class DonorUpdateDTO(int id, string fullName, string email, DateTime doB, string gender, double weight, string bloodType, string rhFactor)
        {
        public int Id { get; set; } = id;
        public string FullName { get; private set; } = fullName;
        public string Email { get; private set; } = email;
        public DateTime DoB { get; private set; } = doB;
        public string Gender { get; private set; } = gender;
        public double Weight { get; private set; } = weight;
        public string BloodType { get; private set; } = bloodType;
        public string RhFactor { get; private set; } = rhFactor;
    }
}
