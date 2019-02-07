using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using OtakuShelter.Manga;
using Phema.Routing;

namespace OtakuShelter.Manga
{
	public static class PagesControllerRoutes
	{
		public static IRoutingBuilder AddPagesController(this IRoutingBuilder builder)
		{
			builder.AddController<PagesController>(controller =>
			{
				controller.AddRoute("{chapterId}/pages", c => c.Create(From.Route<int>(), From.Body<CreatePageViewModel>()))
					.HttpPost()
					.AddFilter(new AuthorizeFilter(new [] { new AuthorizeAttribute() }));

				controller.AddRoute("{chapterId}/pages", c => c.Read(From.Route<int>(), From.Query<FilterViewModel>()))
					.HttpGet();

				controller.AddRoute("pages/{pageId}", c => c.ReadById(From.Route<int>()))
					.HttpGet();

				controller.AddRoute("pages/{pageId}", c => c.Update(From.Route<int>(), From.Body<UpdatePageViewModel>()))
					.HttpPut()
					.AddFilter(new AuthorizeFilter(new [] { new AuthorizeAttribute() }));

				controller.AddRoute("pages/{pageId}", c => c.Delete(From.Route<DeletePageViewModel>()))
					.HttpDelete()
					.AddFilter(new AuthorizeFilter(new [] { new AuthorizeAttribute() }));
			});
			
			return builder;
		}
	}
}