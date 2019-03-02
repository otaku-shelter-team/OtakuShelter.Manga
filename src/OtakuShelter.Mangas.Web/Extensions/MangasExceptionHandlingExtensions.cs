using System;

using Microsoft.Extensions.DependencyInjection;

using Phema.ExceptionHandling;

namespace OtakuShelter.Mangas
{
	public static class MangasExceptionHandlingExtensions
	{
		public static IServiceCollection AddMangasExceptionHandling(this IServiceCollection services)
		{
			return services.AddPhemaExceptionHandling(options =>
					options.AddExceptionHandler<Exception, MangasExceptionHandler>(e => true))
				.AddHttpContextAccessor();
		}
	}
}