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
				controller.AddRoute("{chapterId}/pages", c => c.Read(From.Route<int>(), From.Query<FilterResponse>()))
					.HttpGet();

				controller.AddRoute("pages/{pageId}", c => c.ReadById(From.Route<int>()))
					.HttpGet();
				
				controller.AddRoute("admin/{chapterId}/pages", c => c.AdminCreate(From.Route<int>(), From.Body<AdminCreatePageRequest>()))
					.HttpPost()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/pages/{pageId}", c => c.AdminUpdate(From.Route<int>(), From.Body<AdminUpdatePageRequest>()))
					.HttpPut()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/pages/{pageId}", c => c.AdminDelete(From.Route<AdminDeletePageRequest>()))
					.HttpDelete()
					.Authorize(roles.Admin);
			});
			
			return builder;
		}
	}
}