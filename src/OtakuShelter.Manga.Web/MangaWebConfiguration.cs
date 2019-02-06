using Phema.Configuration;

namespace OtakuShelter.Manga
{
	[Configuration]
	public class MangaWebConfiguration
	{
		public MangaDatabaseConfiguration Database { get; set; }
	}
}