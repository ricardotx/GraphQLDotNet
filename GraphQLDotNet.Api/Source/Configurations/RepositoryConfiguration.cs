using GraphQLDotNet.Core.Source;
using GraphQLDotNet.Core.Source.Repositories;
using GraphQLDotNet.Data.Source;
using GraphQLDotNet.Data.Source.Repositories;

using Microsoft.Extensions.DependencyInjection;

namespace GraphQLDotNet.Api.Source.Configurations
{
	public static class RepositoryConfiguration
	{
		public static void ConfigureRepositories(this IServiceCollection services)
		{
			services
				.AddScoped<IRepository, Repository>()
				.AddScoped<IAccountRepository, AccountRepository>()
				.AddScoped<IOwnerRepository, OwnerRepository>()
				.AddScoped<IRoleRepository, RoleRepository>()
				.AddScoped<IUserRepository, UserRepository>();
		}
	}
}
