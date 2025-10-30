using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.GraphQL.Queries;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp1.GraphQL
{
    public class MySchema : Schema
    {
        public MySchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<GetAccountQuery>();
        }
    }
}
