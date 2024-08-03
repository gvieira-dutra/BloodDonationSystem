using BloodDonationSystem.Infrastructure.PostalCodeService.PostalCodeSettings;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using System.Text.RegularExpressions;

namespace BloodDonationSystem.Infrastructure.PostalCodeService.Service
{
    public class PostalCodeService : IPostalCodeService
    {
        private readonly HttpClient _client;
        private readonly PostalCodeSetUp _postalCodeSetUp;
        public PostalCodeService(IOptions<PostalCodeSetUp> options, IHttpClientFactory factory)
        {
            _postalCodeSetUp = options.Value;
            _client = factory.CreateClient("PCVerifier");
        }

        public bool CheckFormat(string postalCode)
        {
            if (postalCode.Length > 7 || postalCode.Length < 6) { return false; }

            var pcNoSpace = postalCode.Replace(" ", "");

            return pcNoSpace.Length == 6 && Regex.IsMatch(pcNoSpace, @"^[A-Za-z]\d[A-Za-z]\d[A-Za-z]\d$");
        }

        public async Task<bool> CheckPostalCodeAPI(string postalCode)
        {
            var returnHTTPClient = new PostalCodeConsultationReturn();
            var url = $"https://api.zipcodestack.com/v1/search?codes={postalCode}&country=ca&apikey={_postalCodeSetUp.APIKey}";
            try
            {
                returnHTTPClient = await _client.GetFromJsonAsync<PostalCodeConsultationReturn>(url);
            }
            catch (Exception ex)
            {
                throw new ValidationException("Postal Code does not match Canada Postal Code Database.");
            }

            return returnHTTPClient.Results.Count() > 0;
        }
    }
}
