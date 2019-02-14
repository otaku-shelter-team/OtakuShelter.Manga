using Phema.Routing;

namespace OtakuShelter.Manga
{
	public static class TypesControllerRoutes
	{
		public static IRoutingBuilder AddTypesController(this IRoutingBuilder builder)
		{
			builder.AddController<TypesController>("types", controller =>
			{
				controller.AddRoute(c => c.Create(From.Body<CreateTypeViewModel>()))
					.HttpPost()
					.Authorize("admin");

				controller.AddRoute(c => c.Read(From.Body<FilterViewModel>()))
					.HttpGet();

				controller.AddRoute("{typeId}", c => c.Update(From.Route<int>(), From.Body<UpdateTypeViewModel>()))
					.HttpPut()
					.Authorize("admin");

				controller.AddRoute("{typeId}", c => c.Delete(From.Route<DeleteTypeViewModel>()))
					.HttpDelete()
					.Authorize("admin");
			});
			
			return builder;
		}
	}
}