namespace OtakuShelter.Manga
{
	public class MangaTag
	{
		public MangaTag()
		{
		}

		public MangaTag(Tag tag)
		{
			Tag = tag;
		}

		public MangaTag(Tag tag, Manga manga) : this(tag)
		{
			Manga = manga;
		}
		
		public int MangaId { get; set; }
		public int TagId { get; set; }
		
		public virtual Manga Manga { get; set; }
		public virtual Tag Tag { get; set; }
	}
}