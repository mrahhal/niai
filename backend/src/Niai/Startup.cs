using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using AutoMapper.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			services.ConfigureFromAttributes(typeof(Startup).Assembly);

			services.AddResponseCompression();

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
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseResponseCompression();

			app.UseMvc();
		}
	}
}
