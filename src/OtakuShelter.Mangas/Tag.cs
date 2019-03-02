using System.Collections.Generic;

namespace OtakuShelter.Mangas
{
	public class Tag
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public virtual ICollection<MangaTag> Mangas { get; set; }
	}
}