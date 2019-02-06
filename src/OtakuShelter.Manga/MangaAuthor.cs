namespace OtakuShelter.Manga
{
	public class MangaAuthor
	{
		public MangaAuthor()
		{
		}
		
		public MangaAuthor(Author author, Manga manga)
		{
			Author = author;
			Manga = manga;
		}

		public int MangaId { get; set; }
		public int AuthorId { get; set; }

		public virtual Manga Manga { get; set; }
		public virtual Author Author { get; set; }
	}
}