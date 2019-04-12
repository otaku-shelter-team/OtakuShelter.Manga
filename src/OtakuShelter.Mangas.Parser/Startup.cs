using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace OtakuShelter.Mangas
{
	public class Startup : IStartup
	{
		private readonly MangasParserConfiguration configuration;

		public Startup(IOptions<MangasParserConfiguration> configuration)
		{
			this.configuration = configuration.Value;
		}

		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			services.AddHostedService<MangaParserHostedService>()
				.AddMangasDatabase(configuration.Database)
				.AddSingleton<IMangaParser, DefaultMangaParser>();

			return services.BuildServiceProvider();
		}

		public void Configure(IApplicationBuilder app)
		{
		}
	}
}