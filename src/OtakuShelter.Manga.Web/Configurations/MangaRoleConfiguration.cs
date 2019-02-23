using Phema.Configuration;

namespace OtakuShelter.Manga
{
	[Configuration]
	public class MangaRoleConfiguration
	{
		public string Admin { get; set; }
		public string User { get; set; }
	}
}