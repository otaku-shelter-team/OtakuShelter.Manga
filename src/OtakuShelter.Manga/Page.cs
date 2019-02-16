using System.Collections.Generic;

namespace OtakuShelter.Manga
{
	public class Page
	{
		public int Id { get; set; }
		public int Order { get; set; }
		public string Image { get; set; }

		public int ChapterId { get; set; }
		public virtual Chapter Chapter { get; set; }
		public virtual ICollection<Bookmark> Bookmarks { get; set; }
	}
}