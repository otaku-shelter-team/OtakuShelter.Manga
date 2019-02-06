using System.Collections.Generic;

namespace OtakuShelter.Manga
{
	public class Manga
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }

		public int TypeId { get; set; }
		public virtual Type Type { get; set; }

		public virtual ICollection<MangaTag> Tags { get; set; }
		public virtual ICollection<Chapter> Chapters { get; set; }
		public virtual ICollection<MangaTranslator> Translators { get; set; }
		public virtual ICollection<MangaAuthor> Authors { get; set; }
	}
}