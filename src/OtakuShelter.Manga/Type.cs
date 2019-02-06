using System.Collections.Generic;

namespace OtakuShelter.Manga
{
	public class Type
	{
		public int Id { get; set; }
		public string Name { get; set; }
		
		public virtual ICollection<Manga> Mangas { get; set; }
	}
}