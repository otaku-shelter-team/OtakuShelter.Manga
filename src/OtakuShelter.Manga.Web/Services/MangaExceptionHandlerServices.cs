using System;

using Microsoft.Extensions.DependencyInjection;

using Phema.ExceptionHandling;

namespace OtakuShelter.Manga
{
	public static class MangaExceptionHandlerServices
	{
		public static IServiceCollection AddExceptionHandlingServices(this IServiceCollection services)
		{
			return services.AddPhemaExceptionHandling(options =>
				options.AddExceptionHandler<Exception, MangaExceptionHandler>(e => true));
		}
	}
}