using Phema.Routing;

namespace OtakuShelter.Manga
{
	public static class TypesControllerRoutes
	{
		public static IRoutingBuilder AddTypesController(this IRoutingBuilder builder, MangaRoleConfiguration roles)
		{
			builder.AddController<TypesController>(controller =>
			{
				controller.AddRoute("types", c => c.Read(From.Body<FilterResponse>()))
					.HttpGet();

				controller.AddRoute("admin/types", c => c.AdminCreate(From.Body<AdminCreateTypeRequest>()))
					.HttpPost()
					.Authorize(roles.Admin);
				
				controller.AddRoute("admin/types/{typeId}", c => c.AdminUpdate(From.Route<int>(), From.Body<AdminUpdateTypeRequest>()))
					.HttpPut()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/types/{typeId}", c => c.AdminDelete(From.Route<AdminDeleteTypeRequest>()))
					.HttpDelete()
					.Authorize(roles.Admin);
			});
			
			return builder;
		}
	}
}