using System.Collections.Generic;
using System.Linq;

using Microsoft.Extensions.DependencyInjection;

using Swashbuckle.AspNetCore.Swagger;

namespace OtakuShelter.Manga
{
	public static class MangaSwaggerServices
	{
		public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
		{
		
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new Info {Title = "OtakuShelter Manga API", Version = "v1"});
				
				options.AddSecurityDefinition("Bearer", new ApiKeyScheme
				{
					Description = "JWT Authorization header",
					Name = "Authorization",
					In = "header",
					Type = "apiKey"
				});
				
				options.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
				{
					["Bearer"] = Enumerable.Empty<string>()
				});
			});
			
			return services;
		}
	}
}