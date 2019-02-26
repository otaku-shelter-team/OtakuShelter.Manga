using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Phema.Configuration.Yaml;

namespace OtakuShelter.Manga
{
	public class MangaContextFactory : IDesignTimeDbContextFactory<MangaContext>
	{
		public MangaContext CreateDbContext(string[] args)
		{
			var configurationBuilder = new ConfigurationBuilder();
			ConfigureBuilder(configurationBuilder, Directory.GetCurrentDirectory());
			var configuration = configurationBuilder.Build();
			
			var database = configuration.GetSection("database").Get<MangaContextConfiguration>();

			var optionsBuilder = new DbContextOptionsBuilder<MangaContext>();
			ConfigureContext(optionsBuilder, database);
			var options = optionsBuilder.Options;
			
			return new MangaContext(options);
		}

		public static void ConfigureBuilder(IConfigurationBuilder builder, string path)
		{
			builder.SetBasePath(path)
				.AddYamlFile("appsettings.yml")
				.AddEnvironmentVariables("OTAKUSHELTER:");
		}

		public static void ConfigureContext(DbContextOptionsBuilder options, MangaContextConfiguration mangaContext)
		{
			options.UseNpgsql(mangaContext.ConnectionString, builder =>
					builder.MigrationsHistoryTable(mangaContext.MigrationsTable))
				.ConfigureWarnings(builder => builder.Throw(RelationalEventId.QueryClientEvaluationWarning));
		}
	}
}