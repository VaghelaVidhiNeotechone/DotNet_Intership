using Company_module.Models.Enums;


namespace Company_module.Models.POCO.Request.CompanyDetail
{
    public class CompanyDetailFilter
    {
        public string companyname { get; set; }
        public Guid? countryid { get; set; }
        public Status? status { get; set; }
    }
}
