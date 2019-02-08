using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using OtakuShelter.Manga;
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
					.Authorize();

				controller.AddRoute(c => c.Read(From.Body<FilterViewModel>()))
					.HttpGet();

				controller.AddRoute("{typeId}", c => c.Update(From.Route<int>(), From.Body<UpdateTypeViewModel>()))
					.HttpPut()
					.Authorize();

				controller.AddRoute("{typeId}", c => c.Delete(From.Route<DeleteTypeViewModel>()))
					.HttpDelete()
					.Authorize();
			});
			
			return builder;
		}
	}
}