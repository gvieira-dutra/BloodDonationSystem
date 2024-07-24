using BloodDonationSystem.Application.DTO;
using BloodDonationSystem.Application.Interfaces;
using BloodDonationSystem.Core.Entities;
using BloodDonationSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Application.Services.Implementation
{
    public class DonorService(BloodDonationDbContext dbContext) : IDonor
    {
        private readonly BloodDonationDbContext _dbContext = dbContext;

        public List<Donor> GetAll()
        {
            var donors = _dbContext.Donors
                .Include(a => a.Address)
                .ToList();

            return donors;
        }

        public Donor GetOne(int id)
        {
            var donor = _dbContext.Donors.FirstOrDefault(a => a.Id == id);

            return donor;
        }

        public DonorDTO Post(DonorInputModel newDonor)
        {
            var address = new Address(newDonor.Address.Street, newDonor.Address.City, newDonor.Address.Province, newDonor.Address.PostalCode); 
            _dbContext.Addresses.Add(address);
            _dbContext.SaveChanges(); 

            var donor = new Donor(newDonor.FullName, newDonor.Email, newDonor.DoB, newDonor.Gender, newDonor.Weight, newDonor.BloodType, newDonor.RhFactor, address.Id);
            _dbContext.Donors.Add(donor);
            _dbContext.SaveChanges(); 

            // Map entities to DTOs
            var donorDTO = new DonorDTO
            {
                Id = donor.Id,
                FullName = donor.FullName,
                Email = donor.Email,
                DoB = donor.DoB,
                Gender = donor.Gender,
                Weight = donor.Weight,
                BloodType = donor.BloodType,
                RhFactor = donor.RhFactor,
                Address = new AddressDTO
                {
                    Id = address.Id,
                    Street = address.Street,
                    City = address.City,
                    Province = address.Province,
                    PostalCode = address.PostalCode
                }
            };

            return donorDTO;
        }

    }
}
