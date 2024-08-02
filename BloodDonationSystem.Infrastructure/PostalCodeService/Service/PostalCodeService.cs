using BloodDonationSystem.Infrastructure.PostalCodeService.PostalCodeSettings;
using MailKit;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.RegularExpressions;

namespace BloodDonationSystem.Infrastructure.PostalCodeService.Service
{
    public class PostalCodeService : IPostalCodeService
    {
        private readonly HttpClient _client;
        private readonly PostalCodeSetUp _postalCodeSetUp;
        public PostalCodeService(IOptions<PostalCodeSetUp> options)
        {
            _postalCodeSetUp = options.Value;
        }

        public bool CheckFormat(string postalCode)
        {
            if (postalCode.Length > 7 || postalCode.Length < 6) { return false; }

            var pcNoSpace = postalCode.Replace(" ", "");

            return pcNoSpace.Length == 6 && Regex.IsMatch(pcNoSpace, @"^[A-Za-z]\d[A-Za-z]\d[A-Za-z]\d$");
        }

        public async Task<bool> CheckPostalCodeAPI(string postalCode)
        {
            var url = $"https://api.zipcodestack.com/v1/search?codes={postalCode}&country=ca&apikey={_postalCodeSetUp.APIKey}";

            var returnHTTPClient = await _client.GetFromJsonAsync<PostalCodeConsultationReturn>(url);

            return false;
        }
    }
}

//{
//    "fullName": "string",
//  "email": "string@mail.com",
//  "doB": "2024-08-02T11:32:14.942Z",
//  "gender": "male",
//  "weight": 40,
//  "bloodType": "string",
//  "rhFactor": "string",
//  "address": {
//        "street": "string",
//    "city": "string",
//    "province": "string",
//    "postalCode": "m4y1r5"
//  }
//}