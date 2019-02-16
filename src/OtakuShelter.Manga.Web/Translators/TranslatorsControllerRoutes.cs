using Phema.Routing;

namespace OtakuShelter.Manga
{
	public static class TranslatorsControllerRoutes
	{
		public static IRoutingBuilder AddTranslatorsController(this IRoutingBuilder builder)
		{
			builder.AddController<TranslatorsController>(controller =>
			{
				controller.AddRoute("translators", c => c.Read(From.Query<FilterByMangaIdViewModel>()))
					.HttpGet();
				
				controller.AddRoute("admin/translators", c => c.AdminCreate(From.Body<AdminCreateTranslatorViewModel>()))
					.HttpPost()
					.Authorize("admin");

				controller.AddRoute("admin/translators/{translatorId}", c => c.AdminUpdate(From.Route<int>(), From.Body<AdminUpdateTranslatorViewModel>()))
					.HttpPut()
					.Authorize("admin");

				controller.AddRoute("admin/translators/{translatorId}", c => c.AdminDelete(From.Route<AdminDeleteTranslatorViewModel>()))
					.HttpDelete()
					.Authorize("admin");
			});
			
			return builder;
		}
	}
}