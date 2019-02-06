using System.Runtime.Serialization;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadPageItemViewModel
	{
		public ReadPageItemViewModel(Page page)
		{
			Id = page.Id;
			Image = page.Image;
		}

		public int Id { get; }
		public string Image { get; }
	}
}