using Phema.Routing;

namespace OtakuShelter.Mangas
{
	public static class AuthorsControllerRoutes
	{
		public static IRoutingBuilder AddAuthorsController(this IRoutingBuilder builder, MangasRoleConfiguration roles)
		{
			builder.AddController<AuthorsController>(controller =>
			{
				controller.AddRoute("authors", c => c.Read(From.Query<FilterRequest>()))
					.HttpGet();

				controller.AddRoute("authors/{mangaId}",
						c => c.ReadById(From.Route<int>(), From.Query<FilterRequest>()))
					.HttpGet();

				controller.AddRoute("admin/authors", c => c.AdminCreate(From.Body<AdminCreateAuthorRequest>()))
					.HttpPost()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/authors/{authorId}",
						c => c.AdminUpdate(From.Route<int>(), From.Body<AdminUpdateAuthorRequest>()))
					.HttpPut()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/authors/{authorId}", c => c.AdminDelete(From.Route<AdminDeleteAuthorRequest>()))
					.HttpDelete()
					.Authorize(roles.Admin);
			});

			return builder;
		}
	}
}