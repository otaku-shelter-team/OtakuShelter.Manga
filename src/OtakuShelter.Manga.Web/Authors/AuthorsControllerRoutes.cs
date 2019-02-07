using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
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
					.AddFilter(new AuthorizeFilter(new []{ new AuthorizeAttribute() }));

				controller.AddRoute(c => c.Read(From.Query<FilterViewModel>()))
					.HttpGet();

				controller.AddRoute("{authorId}", c => c.Update(From.Route<int>(), From.Body<UpdateAuthorViewModel>()))
					.HttpPut()
					.AddFilter(new AuthorizeFilter(new []{ new AuthorizeAttribute() }));

				controller.AddRoute("{authorId}", c => c.Delete(From.Route<DeleteAuthorViewModel>()))
					.HttpDelete()
					.AddFilter(new AuthorizeFilter(new []{ new AuthorizeAttribute() }));
			});
			
			return builder;
		}
	}
}