using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using MR.AttributeDI;

namespace Niai.Services
{
	[AddToServices(Lifetime.Singleton, AsImplementedInterface = true)]
	public class DataFileProvider : IDataFileProvider
	{
		private readonly IHostingEnvironment _env;

		public DataFileProvider(IHostingEnvironment env)
		{
			_env = env;
		}

		public async Task<string> GetContentsAsync(string name)
		{
			var fileInfo = _env.ContentRootFileProvider.GetFileInfo($"data/{name}.json");
			using (var stream = fileInfo.CreateReadStream())
			using (var reader = new StreamReader(stream))
			{
				return await reader.ReadToEndAsync();
			}
		}
	}
}
