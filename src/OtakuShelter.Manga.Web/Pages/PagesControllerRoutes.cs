using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using OtakuShelter.Manga;
using Phema.Routing;

namespace OtakuShelter.Manga
{
	public static class PagesControllerRoutes
	{
		public static IRoutingBuilder AddPagesController(this IRoutingBuilder builder, MangaRoleConfiguration roles)
		{
			builder.AddController<PagesController>(controller =>
			{
				controller.AddRoute("{chapterId}/pages", c => c.Read(From.Route<int>(), From.Query<FilterViewModel>()))
					.HttpGet();

				controller.AddRoute("pages/{pageId}", c => c.ReadById(From.Route<int>()))
					.HttpGet();
				
				controller.AddRoute("admin/{chapterId}/pages", c => c.AdminCreate(From.Route<int>(), From.Body<AdminCreatePageViewModel>()))
					.HttpPost()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/pages/{pageId}", c => c.AdminUpdate(From.Route<int>(), From.Body<AdminUpdatePageViewModel>()))
					.HttpPut()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/pages/{pageId}", c => c.AdminDelete(From.Route<AdminDeletePageViewModel>()))
					.HttpDelete()
					.Authorize(roles.Admin);
			});
			
			return builder;
		}
	}
}