using GraphQL.Types;
using GraphQL.Utilities;

using GraphQLDotNet.Api.Source.Mutations;
using GraphQLDotNet.Api.Source.Queries;

using System;

namespace GraphQLDotNet.Api.Source.GraphQL
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
