using System.Runtime.Serialization;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadPageItemResponse
	{
		public ReadPageItemResponse(Page page)
		{
			Id = page.Id;
			Image = page.Image;
		}

		public int Id { get; }
		public string Image { get; }
	}
}