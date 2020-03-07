using System;
using System.IO;
using System.Linq;
using System.Reflection;
using AutoMapper;
using AutoMapper.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MR.AttributeDI.ServiceCollection;

namespace Niai
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers()
				.AddNestedRouting(useKebabCase: true);

			services.ConfigureFromAttributes(typeof(Startup).Assembly);

			services.AddResponseCompression();

			services.AddCors(options =>
			{
				options.AddDefaultPolicy(p => p
					.AllowAnyHeader()
					.AllowAnyMethod()
					.AllowAnyOrigin());
			});

			var entryAssembly = Assembly.GetExecutingAssembly();
			var mapperConfiguration = new MapperConfiguration(config =>
			{
				var excludedTypes = new[]
				{
					typeof(object),
					typeof(ValueType),
					typeof(Enum),
					typeof(IComparable),
					typeof(IFormattable),
					typeof(IConvertible)
				};

				var efDynamicProxiesNamespace = "System.Data.Entity.DynamicProxies";

				config.AddConditionalObjectMapper()
					.Where((t1, t2) => !excludedTypes.Contains(t1) && !excludedTypes.Contains(t2))
					.Where((t1, t2) => t1.Namespace != efDynamicProxiesNamespace && t2.Namespace != efDynamicProxiesNamespace);

				config.AddProfiles(entryAssembly);

				config.ValidateInlineMaps = false;
			});
			var mapper = mapperConfiguration.CreateMapper();

			services.AddSingleton<AutoMapper.IConfigurationProvider>(mapperConfiguration);
			services.AddSingleton(mapper);

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Niai API", Version = "v1" });
				c.CustomSchemaIds(x => x.FullName);

				var xmlFile = $"{entryAssembly.GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				c.IncludeXmlComments(xmlPath);
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseForwardedHeaders(new ForwardedHeadersOptions
			{
				ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto,
			});

			app.UseResponseCompression();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Niai");
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
