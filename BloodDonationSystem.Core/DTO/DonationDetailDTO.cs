namespace BloodDonationSystem.Core.DTO
{
    public class DonationDetailDTO(int id, DateTime date, int quantity, string name, string email, string bloodType, string rhFactor)
    {

        public int Id { get; private set; } = id;
        public DateTime DonationDate { get; private set; } = date;
        public int Quantity { get; private set; } = quantity;
        public string DonorName { get; private set; } = name;
        public string DonorEmail { get; private set; } = email;

        public string BloodType { get; private set; } = bloodType;
        public string RhFactor { get; private set; } = rhFactor;
    }

}
