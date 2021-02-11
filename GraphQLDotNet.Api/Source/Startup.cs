using GraphQL.Server;
using GraphQL.Server.Ui.Playground;

using GraphQLDotNet.Api.GraphQL.Source;
using GraphQLDotNet.Api.Source.GraphQL.Resolvers;
using GraphQLDotNet.Core.Source;
using GraphQLDotNet.Core.Source.Repositories;
using GraphQLDotNet.Core.Source.Resolvers;
using GraphQLDotNet.Core.Source.Services;
using GraphQLDotNet.Data.Source;
using GraphQLDotNet.Data.Source.Context;
using GraphQLDotNet.Data.Source.Repositories;
using GraphQLDotNet.Services.Source;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace GraphQLDotNet.Api.Source
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
				// GraphQL playground config (Only in dev)
				app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			// GraphQL enpoint
			app.UseGraphQL<GraphQLSchema>();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Database connection
			string connectionStr = Configuration.GetConnectionString("mysqlConString");
			services.AddDbContext<StorageContext>(opt => opt.UseMySql(connectionStr, ServerVersion.AutoDetect(connectionStr)));

			// Repositories
			services.AddScoped<IRepository, Repository>();
			services.AddScoped<IAccountRepository, AccountRepository>();
			services.AddScoped<IOwnerRepository, OwnerRepository>();
			services.AddScoped<IRoleRepository, RoleRepository>();
			services.AddScoped<IUserRepository, UserRepository>();

			// Services
			services.AddScoped<IOwnerService, OwnerService>();
			services.AddScoped<IAccountService, AccountService>();
			services.AddScoped<IDataLoaderService, DataLoaderService>();
			services.AddScoped<IRoleService, RoleService>();
			services.AddScoped<IUserService, UserService>();

			// Resolvers
			services.AddScoped<IOwnerResolver, OwnerResolver>();
			services.AddScoped<IAccountResolver, AccountResolver>();

			// GraphQL
			services.AddScoped<GraphQLSchema>();
			services.AddGraphQL()
				.AddSystemTextJson()
				.AddGraphTypes(typeof(GraphQLSchema), ServiceLifetime.Scoped)
				.AddDataLoader();

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraphQLDotNet.Api", Version = "v1" });
			});
		}
	}
}
