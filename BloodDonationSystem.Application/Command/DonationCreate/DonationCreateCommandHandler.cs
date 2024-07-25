using BloodDonationSystem.Application.ViewModels;
using BloodDonationSystem.Core.Entities;
using BloodDonationSystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Application.Command.DonationCreate
{
    public class DonationCreateCommandHandler : IRequestHandler<DonationCreateCommand, int>
    {
        private readonly BloodDonationDbContext _dbContext;

        public DonationCreateCommandHandler(BloodDonationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(DonationCreateCommand request, CancellationToken cancellationToken)
        {

            var donor = await _dbContext.Donors.FirstOrDefaultAsync(a => a.Id == request.DonorId);
            var donations = _dbContext.Donations;

            var bloodStock = await _dbContext.BloodStocks.FirstOrDefaultAsync(a => a.RhFactor == donor.RhFactor && a.BloodType == donor.BloodType);

            var donation = new Donation(request.DonorId, request.Quantity);

            donor.Donations.Add(donation);

            donations.Add(donation);

            bloodStock.updateQuantity(request.Quantity);

            var donationViewModel = new DonationViewModel(
                DateTime.Now,
                request.Quantity,
                donor.FullName,
                donor.Email,
                donor.BloodType,
                donor.RhFactor
                );

            await _dbContext.SaveChangesAsync();

            return donor.Id;
        }

        //async Task<int> IRequestHandler<DonationCreateCommand, int>.Handle(DonationCreateCommand request, CancellationToken cancellationToken)
        //{
        //    var donor = await _dbContext.Donors.FirstOrDefaultAsync(a => a.Id == request.DonorId);
        //    var donations = _dbContext.Donations;

        //    var bloodStock = await _dbContext.BloodStocks.FirstOrDefaultAsync(a => a.RhFactor == donor.RhFactor && a.BloodType == donor.BloodType);

        //    var donation = new Donation(request.DonorId, request.Quantity);

        //    donor.Donations.Add(donation);

        //    donations.Add(donation);

        //    bloodStock.updateQuantity(request.Quantity);

        //    var donationViewModel = new DonationViewModel(
        //        DateTime.Now,
        //        request.Quantity,
        //        donor.FullName,
        //        donor.Email,
        //        donor.BloodType,
        //        donor.RhFactor
        //        );

        //    await _dbContext.SaveChangesAsync();

        //    return donor.Id;
        //}
    }
}
