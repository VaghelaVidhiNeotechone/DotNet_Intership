using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GraphQL;

namespace ConsoleApp1.Resolvers
{
    public class UserResolver : IResolver
    {
        public async Task<User> ResolveAsync(IResolveFieldContext context, CancellationToken cancellationToken)
        {
            var userId = context.GetArgument<string>("userId");

            // Simulate long-running work
            await Task.Delay(2000, cancellationToken); // Supports cancellation

            return new User
            {
                Id = userId,
                Name = "John Doe"
            };
        }
    }
}
