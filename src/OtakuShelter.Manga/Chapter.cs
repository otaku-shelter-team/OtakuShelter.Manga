using System;
using System.Collections.Generic;

namespace OtakuShelter.Manga
{
	public class Chapter
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public int Order { get; set; }
		public DateTime UploadDate { get; set; }

		public int MangaId { get; set; }
		public virtual Manga Manga { get; set; }
		
		public virtual ICollection<Page> Pages { get; set; }
	}
}