using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phema.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace OtakuShelter.Manga
{
	public static class MangaWebServices
	{
		public static IServiceCollection AddWebServices(
			this IServiceCollection services,
			MangaWebConfiguration configuration)
		{
			services.AddMvcCore()
				.AddJsonFormatters()
				.AddAuthorization()
				.AddApiExplorer()
				.AddPhemaRouting(routing => 
					routing.AddMangasController()
						.AddChaptersController()
						.AddPagesController()
						.AddTypesController()
						.AddTagsController()
						.AddTranslatorsController()
						.AddAuthorsController())
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			services.AddAuthorization();
			
			var secret = Encoding.ASCII.GetBytes(configuration.Secret);
			services.AddAuthentication(x =>
				{
					x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				.AddJwtBearer(x =>
				{
					x.RequireHttpsMetadata = false;
					x.SaveToken = true;
					x.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(secret),
						ValidateIssuer = true,
						ValidIssuer = configuration.Issuer,
						ValidateAudience = true,
						ValidAudience = configuration.Audience
					};
				});
			
			services.AddSwaggerGen(options => 
				options.SwaggerDoc("v1", new Info { Title = "OtakuShelter Manga API", Version = "v1" }));
			
			return services;
		}

		public static void EnsureDatabaseMigrated(this IApplicationBuilder app)
		{
			using (var scope = app.ApplicationServices.CreateScope())
			{
				scope.ServiceProvider
					.GetRequiredService<MangaContext>()
					.Database
					.Migrate();
			}
		}
	}
}