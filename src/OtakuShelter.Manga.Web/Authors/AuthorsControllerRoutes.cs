using Phema.Routing;

namespace OtakuShelter.Manga
{
	public static class AuthorsControllerRoutes
	{
		public static IRoutingBuilder AddAuthorsController(this IRoutingBuilder builder)
		{
			builder.AddController<AuthorsController>("authors", controller =>
			{
				controller.AddRoute(c => c.Create(From.Body<CreateAuthorViewModel>()))
					.HttpPost()
					.Authorize("admin");

				controller.AddRoute(c => c.Read(From.Query<FilterViewModel>()))
					.HttpGet();

				controller.AddRoute("{authorId}", c => c.Update(From.Route<int>(), From.Body<UpdateAuthorViewModel>()))
					.HttpPut()
					.Authorize("admin");

				controller.AddRoute("{authorId}", c => c.Delete(From.Route<DeleteAuthorViewModel>()))
					.HttpDelete()
					.Authorize("admin");
			});
			
			return builder;
		}
	}
}