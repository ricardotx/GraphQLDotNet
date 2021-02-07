using GraphQL.Server.Ui.Playground;

using GraphQLDotNet.Api.GraphQL.Source;
using GraphQLDotNet.Api.Source.Configurations;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
			// Configure our services
			services.ConfigureDbContext(Configuration);
			services.ConfigureRepositories();
			services.ConfigureServices();
			services.ConfigureGraphQLResolvers();
			services.ConfigureGraphQL();

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraphQLDotNet.Api", Version = "v1" });
			});
		}
	}
}
