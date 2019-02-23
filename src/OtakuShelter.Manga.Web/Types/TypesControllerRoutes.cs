using Phema.Routing;

namespace OtakuShelter.Manga
{
	public static class TypesControllerRoutes
	{
		public static IRoutingBuilder AddTypesController(this IRoutingBuilder builder, MangaRoleConfiguration roles)
		{
			builder.AddController<TypesController>(controller =>
			{
				controller.AddRoute("types", c => c.Read(From.Body<FilterViewModel>()))
					.HttpGet();

				controller.AddRoute("admin/types", c => c.AdminCreate(From.Body<AdminCreateTypeViewModel>()))
					.HttpPost()
					.Authorize(roles.Admin);
				
				controller.AddRoute("admin/types/{typeId}", c => c.AdminUpdate(From.Route<int>(), From.Body<AdminUpdateTypeViewModel>()))
					.HttpPut()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/types/{typeId}", c => c.AdminDelete(From.Route<AdminDeleteTypeViewModel>()))
					.HttpDelete()
					.Authorize(roles.Admin);
			});
			
			return builder;
		}
	}
}