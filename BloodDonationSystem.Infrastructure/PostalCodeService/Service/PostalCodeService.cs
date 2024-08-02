using BloodDonationSystem.Infrastructure.PostalCodeService.PostalCodeSettings;
using Microsoft.Extensions.Options;

namespace BloodDonationSystem.Infrastructure.PostalCodeService.Service
{
    public class PostalCodeService : IPostalCodeService
    {
        private readonly PostalCodeSetUp _postalCodeSetUp;
        public PostalCodeService(IOptions<PostalCodeSetUp> options)
        {
            _postalCodeSetUp = options.Value;
        }

        public bool CheckFormat(string postalCode)
        {
            if (postalCode.Length > 7 || postalCode.Length < 6) { return false; }

            var pcNoSpace = "";

            if (postalCode.Length == 7)
            {
                for (var i = 0; i < postalCode.Length; i++)
                {
                    if (!postalCode[i].Equals(" "))
                    {
                        pcNoSpace.Append(postalCode[i]);
                    }
                }
            }

            for (var i = 0; i < pcNoSpace.Length; i++)
            {
                if(i % 2 == 0)
                {

                }
                else
                {

                }
            }
            return false;
        }

        //public async Task<bool> CheckPostalCode(string postalCode)
        //{
            
        //}
    }
}
