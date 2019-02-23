using Phema.Routing;

namespace OtakuShelter.Manga
{
	public static class AuthorsControllerRoutes
	{
		public static IRoutingBuilder AddAuthorsController(this IRoutingBuilder builder, MangaRoleConfiguration roles)
		{
			builder.AddController<AuthorsController>(controller =>
			{
				controller.AddRoute("authors", c => c.Read(From.Query<FilterViewModel>()))
					.HttpGet();
				
				controller.AddRoute("{mangaId}/authors",
						c => c.ReadById(From.Route<int>(), From.Query<FilterViewModel>()))
					.HttpGet();
				
				controller.AddRoute("admin/authors", c => c.AdminCreate(From.Body<AdminCreateAuthorViewModel>()))
					.HttpPost()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/authors/{authorId}", c => c.AdminUpdate(From.Route<int>(), From.Body<AdminUpdateAuthorViewModel>()))
					.HttpPut()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/authors/{authorId}", c => c.AdminDelete(From.Route<AdminDeleteAuthorViewModel>()))
					.HttpDelete()
					.Authorize(roles.Admin);
			});
			
			return builder;
		}
	}
}