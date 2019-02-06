using System.IO;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using Phema.Configuration;
using Phema.Configuration.Yaml;

namespace OtakuShelter.Manga
{
	public static class Program
	{
		public static async Task Main(string[] args)
		{
			var app = new WebHostBuilder()
				.UseKestrel()
				.UseWebRoot(Directory.GetCurrentDirectory())
				.ConfigureAppConfiguration((context, builder) =>
					DesignTimeMangaContextFactory
						.CreateConfigurationBuilderConfiguration(context.HostingEnvironment.WebRootPath)(builder))
				.ConfigureLogging((context, builder) =>
					builder.AddConsole()
						.SetMinimumLevel(LogLevel.Warning))
				.UseConfiguration<MangaWebConfiguration>()
				.UseStartup<Startup>()
				.Build();

			await app.RunAsync();
		}
	}
}