using GraphQL.Server;

using GraphQLDotNet.Api.GraphQL.Source;
using GraphQLDotNet.Api.Source.GraphQL.Resolvers;
using GraphQLDotNet.Core.Source.Resolvers;

using Microsoft.Extensions.DependencyInjection;

namespace GraphQLDotNet.Api.Source.Configurations
{
	public static class GraphQLConfiguration
	{
		public static void ConfigureGraphQL(this IServiceCollection services)
		{
			services
				.AddScoped<GraphQLSchema>()
				.AddGraphQL()
				.AddSystemTextJson()
				.AddGraphTypes(typeof(GraphQLSchema), ServiceLifetime.Scoped).AddDataLoader();
		}

		public static void ConfigureGraphQLResolvers(this IServiceCollection services)
		{
			services
				.AddScoped<IOwnerResolver, OwnerResolver>()
				.AddScoped<IAccountResolver, AccountResolver>();
		}
	}
}
