using GraphQLDotNet.Core.Source.Services;
using GraphQLDotNet.Services.Source;

using Microsoft.Extensions.DependencyInjection;

namespace GraphQLDotNet.Api.Source.Configurations
{
	public static class ServicesConfiguration
	{
		public static void ConfigureServices(this IServiceCollection services)
		{
			services.AddScoped<IOwnerService, OwnerService>();
			services.AddScoped<IAccountService, AccountService>();
			services.AddScoped<IDataLoaderService, DataLoaderService>();
			services.AddScoped<IRoleService, RoleService>();
			services.AddScoped<IUserService, UserService>();
		}
	}
}
