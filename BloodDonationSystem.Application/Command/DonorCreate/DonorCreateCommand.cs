using MediatR;

namespace BloodDonationSystem.Application.Command.DonorCreate
{
    public class DonorCreateCommand : IRequest<int>
    {
            public string FullName { get; set; }
            public string Email { get; set; }
            public DateTime DoB { get; set; }
            public string Gender { get; set; }
            public double Weight { get; set; }
            public string BloodType { get; set; }
            public string RhFactor { get; set; }
            public AddressInputModel Address { get; set; }

        public class AddressInputModel
        {
            public string Street { get; set; }
            public string City { get; set; }
            public string Province { get; set; }
            public string PostalCode { get; set; }
        }
    }
}
