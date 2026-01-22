namespace CompanyModule.Resources
{
    public static class APIRouteTemplate
    {
        public const string CompanyDetail = "company-detail";
        public const string Country = "country";
        public const string Currency = "currency";
        public const string CompanyAttachment = "company-attachment";
        
        public static class UserRoutes
        {
            public const string ActiveUser = "activate/{token}";
        }
        
        public static class UserRoleRoutes
        {
            public const string GetAll = "user-roles";
            public const string GetById = "user-roles/{id}";
            public const string Create = "user-roles";
            public const string Update = "user-roles/{id}";
            public const string Delete = "user-roles/{id}";
            public const string UpdateStatus = "user-roles/{id}/status";
            public const string GetAllPaginated = "user-roles/paginated";
            public const string GetAllddlData = "user-roles/ddl";
            public const string Restore = "user-roles/{id}/restore";
            public const string DeleteAll = "user-roles/delete-all";
            public const string Import = "user-roles/import";
        }
    }
}
