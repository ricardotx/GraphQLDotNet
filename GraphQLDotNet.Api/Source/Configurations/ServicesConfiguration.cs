using GraphQL.Server;

using GraphQLDotNet.Api.Source.GraphQL;
using GraphQLDotNet.Api.Source.Resolvers;
using GraphQLDotNet.Core.Source;
using GraphQLDotNet.Core.Source.Repositories;
using GraphQLDotNet.Core.Source.Resolvers;
using GraphQLDotNet.Core.Source.Services;
using GraphQLDotNet.Data.Source;
using GraphQLDotNet.Data.Source.Context;
using GraphQLDotNet.Data.Source.Repositories;
using GraphQLDotNet.Services.Source;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLDotNet.Api.Source.Configurations
{
	public static class ServicesConfiguration
	{
		// Database
		public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			string connectionStr = configuration.GetConnectionString("mysqlConString");
			services
				.AddDbContext<ApplicationContext>(opt => opt.UseMySql(connectionStr, ServerVersion.AutoDetect(connectionStr)));
		}

		// Graphql
		public static void ConfigureGraphQL(this IServiceCollection services)
		{
			services
				.AddScoped<AppSchema>()
				.AddGraphQL()
				.AddSystemTextJson()
				.AddGraphTypes(typeof(AppSchema), ServiceLifetime.Scoped).AddDataLoader();
		}

		// Grapqhl Resolvers
		public static void ConfigureGraphQLResolvers(this IServiceCollection services)
		{
			services
				.AddScoped<IOwnerResolver, OwnerResolver>()
				.AddScoped<IAccountResolver, AccountResolver>();
		}

		// Repository
		public static void ConfigureRepositories(this IServiceCollection services)
		{
			services
				.AddScoped<IRepository, Repository>()
				.AddScoped<IAccountRepository, AccountRepository>()
				.AddScoped<IOwnerRepository, OwnerRepository>()
				.AddScoped<IRoleRepository, RoleRepository>()
				.AddScoped<IUserRepository, UserRepository>();
		}

		// Services
		public static void ConfigureServices(this IServiceCollection services)
		{
			services
				.AddScoped<IOwnerService, OwnerService>()
				.AddScoped<IAccountService, AccountService>()
				.AddScoped<IDataLoaderService, DataLoaderService>();
		}
	}
}
