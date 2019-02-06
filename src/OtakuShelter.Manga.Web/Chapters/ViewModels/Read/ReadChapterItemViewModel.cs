using System.Runtime.Serialization;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadChapterItemViewModel
	{
		[DataMember(Name = "id")]
		public int Id { get; }
		
		[DataMember(Name = "title")]
		public string Title { get; }
		
		public ReadChapterItemViewModel(Chapter chapter)
		{
			Id = chapter.Id;
			Title = chapter.Title;
		}
	}
}