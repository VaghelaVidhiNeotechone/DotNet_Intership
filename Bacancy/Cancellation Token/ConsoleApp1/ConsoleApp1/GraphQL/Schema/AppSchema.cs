using GraphQL.Types;

public class AppSchema : Schema
{
    public AppSchema(IServiceProvider provider) : base(provider)
    {
        Query = provider.GetRequiredService<GetAccountQuery>();
    }
}
