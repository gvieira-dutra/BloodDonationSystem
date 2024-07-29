using BloodDonationSystem.Core.DTO;

using BloodDonationSystem.Core.Entities;

namespace BloodDonationSystem.Core.Repository
{
    public interface IDonationRepository
    {
        Task<List<DonationDetailDTO>> DonationGetRecent();
        Task<int> CreateDonation(Donation aDonation);
        Task DeleteDonation(int donationId, CancellationToken cancellationToken);
        Task<DonationDetailDTO> DonationUpdate(int donationId, int newQty, CancellationToken cancellationToken);
        Task SaveDbChanges();
    }
}