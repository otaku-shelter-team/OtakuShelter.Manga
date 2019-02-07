using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
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
					.HttpPost()
					.AddFilter(new AuthorizeFilter(new [] { new AuthorizeAttribute() }));
				
				controller.AddRoute(c => c.Read(From.Query<FilterViewModel>()))
					.HttpGet();

				controller.AddRoute("{mangaId}", c => c.Read(From.Route<int>()))
					.HttpGet();

				controller.AddRoute("{mangaId}",
						c => c.Update(From.Route<int>(), From.Body<UpdateMangaViewModel>()))
					.HttpPut()
					.AddFilter(new AuthorizeFilter(new [] { new AuthorizeAttribute() }));

				controller.AddRoute("{mangaId}", c => c.Delete(From.Route<DeleteMangaViewModel>()))
					.HttpDelete()
					.AddFilter(new AuthorizeFilter(new [] { new AuthorizeAttribute() }));
			});
			
			return builder;
		}
	}
}