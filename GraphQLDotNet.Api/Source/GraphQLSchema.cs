using GraphQL.Types;
using GraphQL.Utilities;

using GraphQLDotNet.Api.Source.Mutations;
using GraphQLDotNet.Api.Source.Queries;

using System;

namespace GraphQLDotNet.Api.Source
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
