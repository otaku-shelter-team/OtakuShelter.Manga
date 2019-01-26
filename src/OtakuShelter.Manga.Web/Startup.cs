using System;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace OtakuShelter.Manga
{
	public class Startup
	{
		private readonly OtakuShelterWebConfiguration configuration;

		public Startup(IOptions<OtakuShelterWebConfiguration> configuration)
		{
			this.configuration = configuration.Value;
		}
		
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDataModule(configuration.DataConfiguration);
		}

		public void Configure(IApplicationBuilder app)
		{
			app.Run(async context =>
			{
				var database = context.RequestServices.GetRequiredService<OtakuShelterContext>();

				database.Mangas.Add(new Manga());

				await database.SaveChangesAsync();

				var environments = Environment.GetEnvironmentVariables().GetEnumerator();

				var sb = new StringBuilder();
				
				while (environments.MoveNext())
				{
					sb.AppendLine($"{environments.Key}: {environments.Value}");
				}
				
				await context.Response.WriteAsync($"Hello World! {database.Mangas.Count()}\n");
				await context.Response.WriteAsync(sb.ToString());
			});
		}
	}
}