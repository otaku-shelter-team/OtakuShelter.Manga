using Microsoft.Extensions.DependencyInjection;
using Phema.Routing;

namespace OtakuShelter.Manga
{
	public static class MangaWebExtensions
	{
		public static IServiceCollection AddWebServices(
			this IServiceCollection services)
		{
			services.AddMvcCore()
				.AddJsonFormatters()
				.AddPhemaRouting(configuration => 
					configuration.AddMangasController()
						.AddChaptersController());
			
			return services;
		}
	}
}