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
					.HttpPost()
					.Authorize("admin");

				controller.AddRoute(c => c.Read(From.Query<FilterViewModel>()))
					.HttpGet();

				controller.AddRoute("{tagId}", c => c.Update(From.Route<int>(), From.Body<UpdateTagViewModel>()))
					.HttpPut()
					.Authorize("admin");

				controller.AddRoute("{tagId}", c => c.Delete(From.Route<DeleteTagViewModel>()))
					.HttpDelete()
					.Authorize("admin");
			});
			
			return builder;
		}
	}
}