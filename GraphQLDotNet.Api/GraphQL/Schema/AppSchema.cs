using GraphQL.Types;
using GraphQL.Utilities;

using GraphQLDotNet.Api.GraphQL.Mutations;
using GraphQLDotNet.Api.GraphQL.Queries;

using System;

namespace GraphQLDotNet.Api.GraphQL
{
    public class AppSchema : Schema
    {
        public AppSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<RootQuery>();
            Mutation = provider.GetRequiredService<RootMutation>();
        }
    }
}
