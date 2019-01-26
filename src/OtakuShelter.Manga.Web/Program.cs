using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Phema.Configuration;

namespace OtakuShelter.Manga
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateWebHostBuilder(args).Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseConfiguration<OtakuShelterWebConfiguration>()
				.UseStartup<Startup>();
	}
}