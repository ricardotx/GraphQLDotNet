using GraphQL.Server;
using GraphQL.Server.Ui.Playground;

using GraphQLDotNet.Api.GraphQL;
using GraphQLDotNet.Api.GraphQL.Resolvers;
using GraphQLDotNet.Api.GraphQL.Resolvers.Contracts;
using GraphQLDotNet.Data.Context;
using GraphQLDotNet.Data.Repository;
using GraphQLDotNet.Data.Repository.Contracts;
using GraphQLDotNet.Services;
using GraphQLDotNet.Services.Contracts;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace GraphQLDotNet.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphQLDotNet.Api v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			// GraphQL middleware config
			app.UseGraphQL<AppSchema>();
			// GraphQL playground config
			app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Database connection config
			string connectionStr = Configuration.GetConnectionString("mysqlConString");
			services.AddDbContext<ApplicationContext>(opt => opt.UseMySql(connectionStr, ServerVersion.AutoDetect(connectionStr)));

			// Repositories
			services.AddScoped<IDataLoaderRepository, DataLoaderRepository>();
			services.AddScoped<IOwnerRepository, OwnerRepository>();
			services.AddScoped<IAccountRepository, AccountRepository>();

			// Services
			services.AddScoped<IOwnerService, OwnerService>();
			services.AddScoped<IAccountService, AccountService>();

			// GraphQL Resolvers
			services.AddScoped<IOwnerResolver, OwnerResolver>();
			services.AddScoped<IAccountResolver, AccountResolver>();

			// GraphQL config
			services.AddScoped<AppSchema>();
			services.AddGraphQL()
				.AddSystemTextJson()
				.AddGraphTypes(typeof(AppSchema), ServiceLifetime.Scoped)
				.AddDataLoader();

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraphQLDotNet.Api", Version = "v1" });
			});
		}
	}
}
