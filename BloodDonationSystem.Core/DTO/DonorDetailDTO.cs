﻿
namespace BloodDonationSystem.Core.DTO
{
    public class DonorDetailDTO(string fullName, string email, DateTime doB, string gender, double weight, string bloodType, string rhFactor, Address address)
    {
        public string FullName { get; private set; } = fullName;
        public string Email { get; private set; } = email;
        public string Status { get; private set; }
        public DateTime DoB { get; private set; } = doB;
        public string Gender { get; private set; } = gender;
        public double Weight { get; private set; } = weight;
        public string BloodType { get; private set; } = bloodType;
        public string RhFactor { get; private set; } = rhFactor;
        public List<DonationDTO> Donations { get; private set; } = new List<DonationDTO>();
        public Address Address { get; private set; } = address;

        public void SetDonations(List<DonationDTO> donations)
        {
            Donations = donations;
        }

        public void SetStatus()
        {
            var lastDonation = Donations.LastOrDefault();
            Status = "Clear to donate!";

            if (Weight < 110) { Status = "Cannot donate! Must be over 110lb to donate."; }

            if (DoB > DateTime.Now.AddYears(-18)) { Status = "Cannot donate! Must be over 18 to donate."; }

            if (lastDonation != null)
            {
                if (Gender == "male" && lastDonation.DonationDate > DateTime.Now.AddDays(-60))
                {
                    Status = "Cannot donate! Last donation was less than 60 days ago.";
                    return;
                }
                if (Gender == "female" && lastDonation.DonationDate > DateTime.Now.AddDays(-90))
                {
                    Status = "Cannot donate! Last donation was less than 90 days ago.";
                    return;
                }

            }


        }
    }
}
