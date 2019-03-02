namespace OtakuShelter.Mangas
{
	public class MangaTranslator
	{
		public MangaTranslator()
		{
		}
		
		public MangaTranslator(Translator translator, Manga manga)
		{
			Translator = translator;
			Manga = manga;
		}

		public int MangaId { get; set; }
		public int TranslatorId { get; set; }

		public virtual Manga Manga { get; set; }
		public virtual Translator Translator { get; set; }
	}
}