using CompanyModule.Models.Enums;


namespace CompanyModule.Models.POCO.Response.CompanyDetail
{
    public class CompanyDetailResponse
    {
        public Guid companyid { get; set; }
        public string companyname { get; set; }
        public string city { get; set; }
        public Status status { get; set; }
    }

}
