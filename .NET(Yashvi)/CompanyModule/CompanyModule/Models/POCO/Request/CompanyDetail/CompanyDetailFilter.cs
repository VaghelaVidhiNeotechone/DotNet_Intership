using CompanyModule.Models.Enums;


namespace CompanyModule.Models.POCO.Request.CompanyDetail
{
    public class CompanyDetailFilter
    {
        public string companyname { get; set; }
        public Guid? countryid { get; set; }
        public Status? status { get; set; }
    }
}
