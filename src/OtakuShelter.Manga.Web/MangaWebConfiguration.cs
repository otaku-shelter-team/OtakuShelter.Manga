using Phema.Configuration;

namespace OtakuShelter.Manga
{
	[Configuration]
	public class MangaWebConfiguration
	{
		public string Secret { get; set; }
		public string Issuer { get; set; }
		public string Audience { get; set; }
		
		public MangaDatabaseConfiguration Database { get; set; }
	}
}