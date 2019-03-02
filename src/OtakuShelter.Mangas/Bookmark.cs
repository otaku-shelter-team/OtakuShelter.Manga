using System;

namespace OtakuShelter.Mangas
{
	public class Bookmark
	{
		public int Id { get; set; }
		public int AccountId { get; set; }

		public string Name { get; set; }

		public DateTime Created { get; set; }
		
		public int MangaId { get; set; }
		public virtual Manga Manga { get; set; }
		
		public int? ChapterId { get; set; }
		public virtual Chapter Chapter { get; set; }
		
		public int? PageId { get; set; }
		public virtual Page Page { get; set; }
	}
}