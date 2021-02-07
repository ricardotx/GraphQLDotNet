using GraphQL.Types;
using GraphQL.Utilities;

using GraphQLDotNet.Api.Source.GraphQL.Mutations;
using GraphQLDotNet.Api.Source.GraphQL.Queries;

using System;

namespace GraphQLDotNet.Api.GraphQL.Source
{
	public class GraphQLSchema : Schema
	{
		public GraphQLSchema(IServiceProvider provider) : base(provider)
		{
			Query = provider.GetRequiredService<RootQuery>();
			Mutation = provider.GetRequiredService<RootMutation>();
		}
	}
}
