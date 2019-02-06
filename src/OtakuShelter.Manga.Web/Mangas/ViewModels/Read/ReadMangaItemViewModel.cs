namespace OtakuShelter.Manga
{
	public class ReadMangaItemViewModel
	{
		public ReadMangaItemViewModel(Manga manga)
		{
			Id = manga.Id;
			Title = manga.Title;
			Description = manga.Description;
			Image = manga.Image;
		}

		public int Id { get; }
		public string Title { get; }
		public string Description { get; }
		public string Image { get; }
	}
}