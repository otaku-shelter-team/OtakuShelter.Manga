using System.Collections.Generic;

namespace OtakuShelter.Manga
{
	public class Translator
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public virtual ICollection<MangaTranslator> Mangas { get; set; }
	}
}