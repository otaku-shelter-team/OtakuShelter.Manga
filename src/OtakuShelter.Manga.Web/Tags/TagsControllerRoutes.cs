using Phema.Routing;

namespace OtakuShelter.Manga
{
	public static class TagsControllerRoutes
	{
		public static IRoutingBuilder AddTagsController(this IRoutingBuilder builder, MangaRoleConfiguration roles)
		{
			builder.AddController<TagsController>(controller =>
			{
				controller.AddRoute("tags", c => c.Read(From.Query<FilterViewModel>()))
					.HttpGet();
				
				controller.AddRoute("{mangaId}/tags",
						c => c.ReadTagsById(From.Route<int>(), From.Query<FilterViewModel>()))
					.HttpGet();
				
				controller.AddRoute("admin/tags", c => c.AdminCreate(From.Body<AdminCreateTagViewModel>()))
					.HttpPost()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/tags/{tagId}", c => c.AdminUpdate(From.Route<int>(), From.Body<AdminUpdateTagViewModel>()))
					.HttpPut()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/tags/{tagId}", c => c.AdminDelete(From.Route<AdminDeleteTagViewModel>()))
					.HttpDelete()
					.Authorize(roles.Admin);
			});
			
			return builder;
		}
	}
}