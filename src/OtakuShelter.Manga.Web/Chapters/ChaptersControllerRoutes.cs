using OtakuShelter.Manga.ViewModels.Page;
using Phema.Routing;

namespace OtakuShelter.Manga
{
	public static class ChaptersControllerRoutes
	{
		public static IRoutingBuilder AddChaptersController(this IRoutingBuilder builder)
		{
			builder.AddController<ChaptersController>(controller =>
			{
				controller.AddRoute("{mangaId}/chapters", c => c.Create(From.Route<int>(), From.Body<CreateChapterViewModel>()))
					.HttpPost();

				controller.AddRoute("{mangaId}/chapters", c => c.Read(From.Route<int>(), From.Query<PageViewModel>()))
					.HttpGet();

				controller.AddRoute("chapters/{chapterId}", c => c.Read(From.Route<int>()))
					.HttpGet();

				controller.AddRoute("chapters/{chapterId}",
						c => c.Update(From.Route<int>(), From.Body<UpdateChapterViewModel>()))
					.HttpPut();

				controller.AddRoute("chapters/{chapterId}", c => c.Delete(From.Route<DeleteChapterViewModel>()))
					.HttpDelete();
			});
			
			return builder;
		}
	}
}