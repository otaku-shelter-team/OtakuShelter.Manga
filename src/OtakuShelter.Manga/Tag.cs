using System.Collections.Generic;

namespace OtakuShelter.Manga
{
	public class Tag
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public virtual ICollection<MangaTag> MangaTags { get; set; }
	}
}