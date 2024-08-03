using BloodDonationSystem.Core.DTO;

namespace BloodDonationSystem.Core.Repository
{
    public interface IDonorRepository
    {
        Task<List<DonorDTO>> DonorGetAll(CancellationToken cancellationToken);
        Task<DonorDetailDTO> DonorGetOne(int id, CancellationToken cancellationToken);

        Task<int> DonorCreate(Donor newDonor, CancellationToken cancellationToken);
        Task<int> AddressCreate(Address newAddress, CancellationToken cancellationToken);
        Task DonorDelete(int id, CancellationToken cancellationToken);
        Task<DonorDTO> DonorUpdate(DonorUpdateDTO newInfo, CancellationToken cancellation);

    }
}
