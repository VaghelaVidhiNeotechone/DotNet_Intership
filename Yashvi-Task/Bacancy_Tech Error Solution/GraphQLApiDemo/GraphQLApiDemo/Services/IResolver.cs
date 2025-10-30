using GraphQL;
using System.Threading;
using YourProjectName.Models;

public interface IResolver
{
    Task<User> ResolveAsync(IResolveFieldContext context, CancellationToken cancellationToken);
}
