using Microsoft.AspNetCore.Builder;

namespace OtakuShelter.Mangas
{
	public static class CorsExtensions
	{
		public static IApplicationBuilder UseCors(this IApplicationBuilder app, string origin)
		{
			return app.UseCors(options =>
				options.WithOrigins(origin)
					.AllowAnyHeader()
					.AllowAnyMethod()
					.AllowCredentials());
		}
	}
}