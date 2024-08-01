using BloodDonationSystem.Core.DTO;
using BloodDonationSystem.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Infrastructure.Persistence.Repositories
{
    public class DonorRepository : IDonorRepository
    {
        private readonly BloodDonationDbContext _dbContext;

        public DonorRepository(BloodDonationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DonorDTO>> DonorGetAll(CancellationToken cancellationToken)
        {
            var donors = await _dbContext.Donors
            .Where(d => d.IsActive == true)
            .Select(donor => new DonorDTO(
                donor.Id, 
                donor.FullName, 
                donor.Email, 
                donor.Gender, 
                donor.BloodType, 
                donor.RhFactor))
            .ToListAsync(cancellationToken);

            return donors;
        }

        public async Task<DonorDetailDTO> DonorGetOne(int id, CancellationToken cancellationToken)
        {
            var donations = await _dbContext.Donations
                .Where(d => d.DonorId == id)
                .Select(d => new DonationDTO(d.Id, d.DonationDate, d.Quantity))
                .ToListAsync(cancellationToken);

            var donor = await _dbContext.Donors
                .Include(a => a.Address)
                .FirstOrDefaultAsync(a => a.Id == id);

            var donorVM = new DonorDetailDTO(
                donor.FullName,
                donor.Email,
                donor.DoB,
                donor.Gender,
                donor.Weight,
                donor.BloodType,
                donor.RhFactor,
                donor.Address);

            donorVM.SetDonations(donations);
            donorVM.SetStatus();

            return donorVM; 
        }

        public async Task<int> DonorCreate(Donor newDonor, Address newAddress, CancellationToken cancellationToken)
        {
            await _dbContext.Addresses.AddAsync(newAddress);
            await SaveDbChanges(cancellationToken);

            await _dbContext.Donors.AddAsync(newDonor);
            await SaveDbChanges(cancellationToken);

            return newDonor.Id;
        }

        public async Task DonorDelete(int id, CancellationToken cancellationToken)
        {
            var donor = await _dbContext.Donors
                .Where(d => d.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            if (donor != null)
            {
                donor.SetDonorInactive();

                await SaveDbChanges(cancellationToken);
            }

        }

        public async Task<DonorDTO> DonorUpdate(DonorUpdateDTO newInfo, CancellationToken cancellationToken)
        {
            var donor = await _dbContext.Donors
                .Where(d => d.Id == newInfo.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (donor != null)
            {
                donor.UpdateDonorInfo(
                    newInfo.FullName,
                    newInfo.Email,
                    newInfo.DoB,
                    newInfo.Gender,
                    newInfo.Weight,
                    newInfo.BloodType,
                    newInfo.RhFactor);

                await SaveDbChanges(cancellationToken);

                var newDonor = new DonorDTO(
                    donor.Id,
                    donor.FullName,
                    donor.Email,
                    donor.Gender,
                    donor.BloodType,
                    donor.RhFactor
                    );

                return newDonor;
            }

            return null;
        }

        public async Task SaveDbChanges(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
