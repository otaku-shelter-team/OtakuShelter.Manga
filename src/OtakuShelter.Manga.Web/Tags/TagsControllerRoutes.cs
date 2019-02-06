using Microsoft.EntityFrameworkCore;
using Phema.Routing;

namespace OtakuShelter.Manga
{
	public static class TagsControllerRoutes
	{
		public static IRoutingBuilder AddTagsController(this IRoutingBuilder builder)
		{
			builder.AddController<TagsController>("tags", controller =>
			{
				controller.AddRoute(c => c.Create(From.Body<CreateTagViewModel>()))
					.HttpPost();

				controller.AddRoute(c => c.Read(From.Query<FilterViewModel>()))
					.HttpGet();

				controller.AddRoute("{tagId}", c => c.Update(From.Route<int>(), From.Body<UpdateTagViewModel>()))
					.HttpPut();

				controller.AddRoute("{tagId}", c => c.Delete(From.Route<DeleteTagViewModel>()))
					.HttpDelete();
			});
			
			return builder;
		}
	}
}