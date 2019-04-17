using System.Runtime.Serialization;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class ReadPageItemResponse
	{
		public ReadPageItemResponse(Page page)
		{
			Id = page.Id;
			Image = page.Image;
		}

		[DataMember(Name = "id")]
		public int Id { get; }
		
		[DataMember(Name = "image")]
		public string Image { get; }
	}
}