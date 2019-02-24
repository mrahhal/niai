using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using AutoMapper;
using AutoMapper.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MR.AttributeDI.ServiceCollection;
using Swashbuckle.AspNetCore.Swagger;

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
			services.AddMvc()
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
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
				c.SwaggerDoc("v0.1", new Info { Title = entryAssembly.GetName().Name, Version = "v0.1" });
				c.CustomSchemaIds(x => x.FullName);
				c.DescribeAllEnumsAsStrings();
				c.DescribeStringEnumsInCamelCase();
				c.DescribeAllParametersInCamelCase();

				//c.TagActionsBy(api =>
				//{
				//	return new List<string>
				//	{
				//		((ControllerActionDescriptor)api.ActionDescriptor).ControllerTypeInfo.Namespace
				//	};
				//});

				var xmlFile = $"{entryAssembly.GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				c.IncludeXmlComments(xmlPath);
			});
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseCors();

			app.UseResponseCompression();

			app.UseSwagger();

			var apiAssemblyName = Assembly.GetCallingAssembly().GetName().Name;
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v0.1/swagger.json", apiAssemblyName);
			});

			app.UseMvc();
		}
	}
}
