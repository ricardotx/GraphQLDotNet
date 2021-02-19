using GraphQLDotNet.Data.Source.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLDotNet.Api.Source.Configurations
{
	public static class DbContextConfiguration
	{
		public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			string connectionStr = configuration.GetConnectionString("mysqlConString");
			services
				.AddDbContext<StorageContext>(opt => opt.UseMySql(connectionStr, ServerVersion.AutoDetect(connectionStr)));
		}
	}
}
