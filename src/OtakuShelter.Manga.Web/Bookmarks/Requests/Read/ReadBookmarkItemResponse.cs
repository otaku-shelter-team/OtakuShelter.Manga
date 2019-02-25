using System;
using System.Runtime.Serialization;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class ReadBookmarkItemResponse
	{
		[DataMember(Name = "id")]
		public int Id { get; }
		
		[DataMember(Name = "name")]
		public string Name { get; }
		
		[DataMember(Name = "created")]
		public DateTime Created { get; }
		
		[DataMember(Name = "mangaId")]
		public int MangaId { get; }
		
		[DataMember(Name = "chapterId")]
		public int? ChapterId { get; }
		
		[DataMember(Name = "pageId")]
		public int? PageId { get; }

		public ReadBookmarkItemResponse(Bookmark bookmark)
		{
			Id = bookmark.Id;
			Name = bookmark.Name;
			Created = bookmark.Created;
			MangaId = bookmark.MangaId;
			ChapterId = bookmark.ChapterId;
			PageId = bookmark.PageId;
		}
	}
}