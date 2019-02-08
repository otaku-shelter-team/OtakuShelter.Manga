using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using OtakuShelter.Manga;
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
					.HttpPost()
					.Authorize();

				controller.AddRoute("{mangaId}/chapters", c => c.Read(From.Route<int>(), From.Query<FilterViewModel>()))
					.HttpGet();

				controller.AddRoute("chapters/{chapterId}", c => c.Read(From.Route<int>()))
					.HttpGet();

				controller.AddRoute("chapters/{chapterId}",
						c => c.Update(From.Route<int>(), From.Body<UpdateChapterViewModel>()))
					.HttpPut()
					.Authorize();

				controller.AddRoute("chapters/{chapterId}", c => c.Delete(From.Route<DeleteChapterViewModel>()))
					.HttpDelete()
					.Authorize();
			});
			
			return builder;
		}
	}
}