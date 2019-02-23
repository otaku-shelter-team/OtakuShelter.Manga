using Phema.Routing;

namespace OtakuShelter.Manga
{
	public static class TranslatorsControllerRoutes
	{
		public static IRoutingBuilder AddTranslatorsController(this IRoutingBuilder builder, MangaRoleConfiguration roles)
		{
			builder.AddController<TranslatorsController>(controller =>
			{
				controller.AddRoute("translators", c => c.Read(From.Query<FilterViewModel>()))
					.HttpGet();
				
				controller.AddRoute("{mangaId}/translators",
						c => c.ReadById(From.Route<int>(), From.Query<FilterViewModel>()))
					.HttpGet();
				
				controller.AddRoute("admin/translators", c => c.AdminCreate(From.Body<AdminCreateTranslatorViewModel>()))
					.HttpPost()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/translators/{translatorId}", c => c.AdminUpdate(From.Route<int>(), From.Body<AdminUpdateTranslatorViewModel>()))
					.HttpPut()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/translators/{translatorId}", c => c.AdminDelete(From.Route<AdminDeleteTranslatorViewModel>()))
					.HttpDelete()
					.Authorize(roles.Admin);
			});
			
			return builder;
		}
	}
}