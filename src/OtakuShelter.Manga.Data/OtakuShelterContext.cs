using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	internal class OtakuShelterContext : DbContext
	{
		public OtakuShelterContext()
		{
		}

		public OtakuShelterContext(DbContextOptions<OtakuShelterContext> options)
			: base(options)
		{
		}
	}
}