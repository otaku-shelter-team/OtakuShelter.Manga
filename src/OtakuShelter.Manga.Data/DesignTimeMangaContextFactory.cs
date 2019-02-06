using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Phema.Configuration.Yaml;

namespace OtakuShelter.Manga
{
	public class DesignTimeMangaContextFactory : IDesignTimeDbContextFactory<MangaContext>
	{
		public MangaContext CreateDbContext(string[] args)
		{
			var configurationBuilder = new ConfigurationBuilder();
			CreateConfigurationBuilderConfiguration(Directory.GetCurrentDirectory())(configurationBuilder);
			var configuration = configurationBuilder.Build();
			
			var database = configuration.GetSection("database").Get<MangaDatabaseConfiguration>();

			var optionsBuilder = new DbContextOptionsBuilder<MangaContext>();
			CreateDbContextOptionsConfiguration(database)(optionsBuilder);
			var options = optionsBuilder.Options;
			
			return new MangaContext(options);
		}

		public static Action<IConfigurationBuilder> CreateConfigurationBuilderConfiguration(string path)
		{
			return builder => builder
				.SetBasePath(path)
				.AddYamlFile("appsettings.yml");
		}
		
		public static Action<DbContextOptionsBuilder> CreateDbContextOptionsConfiguration(
			MangaDatabaseConfiguration database)
		{
			return options => options.UseNpgsql(database.ConnectionString, builder =>
					builder.MigrationsHistoryTable(database.MigrationsTable))
				.UseLazyLoadingProxies();
		}
	}
}