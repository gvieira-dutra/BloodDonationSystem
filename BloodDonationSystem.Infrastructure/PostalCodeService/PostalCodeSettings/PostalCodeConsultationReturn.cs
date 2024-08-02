namespace BloodDonationSystem.Infrastructure.PostalCodeService.PostalCodeSettings
{
    public class PostalCodeConsultationReturn
    {
        public class Rootobject
        {
            public Query query { get; set; }
            public Results results { get; set; }
        }

        public class Query
        {
            public string[] codes { get; set; }
            public string country { get; set; }
        }

        public class Results
        {
            public M4y1r5[] m4y1r5 { get; set; }
        }

        public class M4y1r5
        {
            public string postal_code { get; set; }
            public string country_code { get; set; }
            public float latitude { get; set; }
            public float longitude { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public object city_en { get; set; }
            public object state_en { get; set; }
            public string state_code { get; set; }
        }

    }
}
