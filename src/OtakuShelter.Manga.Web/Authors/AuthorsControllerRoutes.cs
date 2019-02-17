using Phema.Routing;

namespace OtakuShelter.Manga
{
	public static class AuthorsControllerRoutes
	{
		public static IRoutingBuilder AddAuthorsController(this IRoutingBuilder builder)
		{
			builder.AddController<AuthorsController>(controller =>
			{
				controller.AddRoute("authors", c => c.Read(From.Query<FilterViewModel>()))
					.HttpGet();
				
				controller.AddRoute("admin/authors", c => c.AdminCreate(From.Body<AdminCreateAuthorViewModel>()))
					.HttpPost()
					.Authorize("admin");

				controller.AddRoute("admin/authors/{authorId}", c => c.AdminUpdate(From.Route<int>(), From.Body<AdminUpdateAuthorViewModel>()))
					.HttpPut()
					.Authorize("admin");

				controller.AddRoute("admin/authors/{authorId}", c => c.AdminDelete(From.Route<AdminDeleteAuthorViewModel>()))
					.HttpDelete()
					.Authorize("admin");
			});
			
			return builder;
		}
	}
}