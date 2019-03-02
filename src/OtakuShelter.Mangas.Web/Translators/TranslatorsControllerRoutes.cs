using Phema.Routing;

namespace OtakuShelter.Mangas
{
	public static class TranslatorsControllerRoutes
	{
		public static IRoutingBuilder AddTranslatorsController(this IRoutingBuilder builder, MangasRoleConfiguration roles)
		{
			builder.AddController<TranslatorsController>(controller =>
			{
				controller.AddRoute("translators", c => c.Read(From.Query<FilterResponse>()))
					.HttpGet();
				
				controller.AddRoute("{mangaId}/translators",
						c => c.ReadById(From.Route<int>(), From.Query<FilterResponse>()))
					.HttpGet();
				
				controller.AddRoute("admin/translators", c => c.AdminCreate(From.Body<AdminCreateTranslatorRequest>()))
					.HttpPost()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/translators/{translatorId}", c => c.AdminUpdate(From.Route<int>(), From.Body<AdminUpdateTranslatorRequest>()))
					.HttpPut()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/translators/{translatorId}", c => c.AdminDelete(From.Route<AdminDeleteTranslatorRequest>()))
					.HttpDelete()
					.Authorize(roles.Admin);
			});
			
			return builder;
		}
	}
}