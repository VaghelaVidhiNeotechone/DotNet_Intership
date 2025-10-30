using GraphQL;
using YourProjectName.Models;

public class MyResolver : IResolver
{
    public Task<User> ResolveAsync(IResolveFieldContext context, CancellationToken cancellationToken)
    {
        var userId = context.GetArgument<string>("userId");

        var user = new User
        {
            Id = userId,
            Name = "Demo User"
        };

        return Task.FromResult(user);
    }
}
