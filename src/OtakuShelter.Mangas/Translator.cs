using System.Collections.Generic;

namespace OtakuShelter.Mangas
{
	public class Translator
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public virtual ICollection<MangaTranslator> Mangas { get; set; }
	}
}