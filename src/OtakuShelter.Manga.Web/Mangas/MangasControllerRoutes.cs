using OtakuShelter.Manga;
using Phema.Routing;

namespace OtakuShelter.Manga
{
	public static class MangasControllerRoutes
	{
		public static IRoutingBuilder AddMangasController(this IRoutingBuilder builder)
		{
			builder.AddController<MangasController>("mangas", controller =>
			{
				controller.AddRoute(c => c.Create(From.Body<CreateMangaViewModel>()))
					.HttpPost();
				
				controller.AddRoute(c => c.Read(From.Query<FilterViewModel>()))
					.HttpGet();

				controller.AddRoute("{mangaId}", c => c.Read(From.Route<int>()))
					.HttpGet();

				controller.AddRoute("{mangaId}",
						c => c.Update(From.Route<int>(), From.Body<UpdateMangaViewModel>()))
					.HttpPut();

				controller.AddRoute("{mangaId}", c => c.Delete(From.Route<DeleteMangaViewModel>()))
					.HttpDelete();
			});
			
			return builder;
		}
	}
}