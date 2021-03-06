using Phema.Routing;

namespace OtakuShelter.Mangas
{
	public static class TagsControllerRoutes
	{
		public static IRoutingBuilder AddTagsController(this IRoutingBuilder builder, MangasRoleConfiguration roles)
		{
			builder.AddController<TagsController>(controller =>
			{
				controller.AddRoute("tags", c => c.Read(From.Query<FilterRequest>()))
					.HttpGet();

				controller.AddRoute("tags/{mangaId}",
						c => c.ReadById(From.Route<int>(), From.Query<FilterRequest>()))
					.HttpGet();

				controller.AddRoute("admin/tags", c => c.AdminCreate(From.Body<AdminCreateTagRequest>()))
					.HttpPost()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/tags/{tagId}",
						c => c.AdminUpdate(From.Route<int>(), From.Body<AdminUpdateTagRequest>()))
					.HttpPut()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/tags/{tagId}", c => c.AdminDelete(From.Route<AdminDeleteTagRequest>()))
					.HttpDelete()
					.Authorize(roles.Admin);
			});

			return builder;
		}
	}
}