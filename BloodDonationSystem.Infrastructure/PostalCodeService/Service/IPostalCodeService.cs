namespace BloodDonationSystem.Infrastructure.PostalCodeService.Service
{
    public interface IPostalCodeService
    {
        public bool CheckFormat(string postalCode);
        Task<bool> CheckPostalCodeAPI(string postalCode);

    }
}
