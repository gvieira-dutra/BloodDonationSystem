namespace BloodDonationSystem.Infrastructure.PostalCodeService.PostalCodeSettings
{
  //Class to represent the returned json from the postal code API search
    public class PostalCodeConsultationReturn
    {
        public Query Query { get; set; }
        public Dictionary<string, List<PostaCodeDetails>> Results { get; set; }
    }

    public class Query
    {
        public List<string> Codes { get; set; }
        public string Country { get; set; }
    }

    public class PostaCodeDetails
    {
        public string Postal_code { get; set; }
        public string Country_code { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public object City_en { get; set; }
        public object State_en { get; set; }
        public string State_code { get; set; }
    }

}

