using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	public class OtakuShelterContext : DbContext
	{
		public OtakuShelterContext()
		{
		}

		public OtakuShelterContext(DbContextOptions<OtakuShelterContext> options)
			: base(options)
		{
		}

		public DbSet<Manga> Mangas { get; set; }
		public DbSet<Manga> Chapters { get; set; }
		public DbSet<Manga> Pages { get; set; }
	}
}