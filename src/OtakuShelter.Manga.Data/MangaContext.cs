using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	public class MangaContext : DbContext
	{
		public MangaContext()
		{
		}
		
		public MangaContext(DbContextOptions<MangaContext> options)
			: base(options)
		{
		}

		public DbSet<Chapter> Chapters { get; set; }
		public DbSet<Manga> Mangas { get; set; }
		public DbSet<MangaTag> MangaTags { get; set; }
		public DbSet<Page> Pages { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<Type> Types { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ChapterConfiguration());
			modelBuilder.ApplyConfiguration(new MangaConfiguration());
			modelBuilder.ApplyConfiguration(new MangaTagConfiguration());
			modelBuilder.ApplyConfiguration(new PageConfiguration());
			modelBuilder.ApplyConfiguration(new TagConfiguration());
			modelBuilder.ApplyConfiguration(new TypeConfiguration());
		}
	}
}