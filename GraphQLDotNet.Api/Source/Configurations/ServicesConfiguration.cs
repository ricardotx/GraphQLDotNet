using GraphQL.Server;

using GraphQLDotNet.Api.Source.GraphQL;
using GraphQLDotNet.Api.Source.Resolvers;
using GraphQLDotNet.Core.Source;
using GraphQLDotNet.Core.Source.Resolvers;
using GraphQLDotNet.Core.Source.Services;
using GraphQLDotNet.Data.Source;
using GraphQLDotNet.Data.Source.Context;
using GraphQLDotNet.Services.Source;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLDotNet.Api.Source.Configurations
{
	public static class ServicesConfiguration
	{
		public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			string connectionStr = configuration.GetConnectionString("mysqlConString");
			services.AddDbContext<ApplicationContext>(opt => opt.UseMySql(connectionStr, ServerVersion.AutoDetect(connectionStr)));
		}

		public static void ConfigureGraphQL(this IServiceCollection services)
		{
			services.AddScoped<AppSchema>();
			services.AddGraphQL()
				.AddSystemTextJson()
				.AddGraphTypes(typeof(AppSchema), ServiceLifetime.Scoped).AddDataLoader();
		}

		public static void ConfigureGraphQLResolvers(this IServiceCollection services)
		{
			services.AddScoped<IOwnerResolver, OwnerResolver>();
			services.AddScoped<IAccountResolver, AccountResolver>();
		}

		public static void ConfigureRepositories(this IServiceCollection services)
		{
			services.AddScoped<IRepository, Repository>();
		}

		public static void ConfigureServices(this IServiceCollection services)
		{
			services.AddScoped<IOwnerService, OwnerService>();
			services.AddScoped<IAccountService, AccountService>();
			services.AddScoped<IDataLoaderService, DataLoaderService>();
		}
	}
}
