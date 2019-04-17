using Phema.Routing;

namespace OtakuShelter.Mangas
{
	public static class PagesControllerRoutes
	{
		public static IRoutingBuilder AddPagesController(this IRoutingBuilder builder, MangasRoleConfiguration roles)
		{
			builder.AddController<PagesController>(controller =>
			{
				controller.AddRoute("pages/{chapterId}", c => c.Read(From.Route<int>(), From.Query<FilterRequest>()))
					.HttpGet();

				// TODO:
				// controller.AddRoute("pages/{pageId}", c => c.ReadById(From.Route<int>()))
				// 	.HttpGet();

				controller.AddRoute("admin/{chapterId}/pages",
						c => c.AdminCreate(From.Route<int>(), From.Body<AdminCreatePageRequest>()))
					.HttpPost()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/pages/{pageId}",
						c => c.AdminUpdate(From.Route<int>(), From.Body<AdminUpdatePageRequest>()))
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