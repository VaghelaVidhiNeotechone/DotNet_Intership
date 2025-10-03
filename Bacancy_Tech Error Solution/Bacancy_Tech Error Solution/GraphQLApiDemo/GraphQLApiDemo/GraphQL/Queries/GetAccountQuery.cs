using GraphQL.Types;
using Microsoft.AspNetCore.Http;

public class GetAccountQuery : ObjectGraphType
{
    public GetAccountQuery(IResolver resolver, IHttpContextAccessor accessor)
    {
        FieldAsync<UserType>(
            "getAccount",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "userId" }),
            resolve: async context =>
            {
                var cancellationToken = accessor.HttpContext?.RequestAborted ?? default;
                return await resolver.ResolveAsync(context, cancellationToken);
            });
    }
}
