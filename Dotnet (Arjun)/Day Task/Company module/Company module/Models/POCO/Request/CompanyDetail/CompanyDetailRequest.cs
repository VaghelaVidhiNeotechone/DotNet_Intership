using Company_module.Models.Enums;


namespace Company_module.Models.POCO.Request.CompanyDetail
{
    public class CompanyDetailRequest
    {
        public Guid companyid { get; set; }
        public string companyname { get; set; }
        public string address { get; set; }
        public Guid countryid { get; set; }
        public string timezone { get; set; }
        public string city { get; set; }
        public string phonenumber { get; set; }
        public string workrequesturl { get; set; }
        public Guid currencyid { get; set; }
        public int taxregistrationnumber { get; set; }
        public string language { get; set; }
        public int? pobox { get; set; }
        public Status status { get; set; }
        public bool billable { get; set; }
        public bool settings { get; set; }
        public bool allowworkrequest { get; set; }
        public int thresholdvalue { get; set; }
        public int? vat { get; set; }
        public string purchaserequestemail { get; set; }
        public bool isdeleted { get; set; }
    }
}
