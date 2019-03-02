using System.Runtime.Serialization;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class ReadChapterItemResponse
	{
		[DataMember(Name = "id")]
		public int Id { get; }
		
		[DataMember(Name = "title")]
		public string Title { get; }
		
		public ReadChapterItemResponse(Chapter chapter)
		{
			Id = chapter.Id;
			Title = chapter.Title;
		}
	}
}