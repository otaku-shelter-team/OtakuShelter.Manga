using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class UpdateMangaViewModel
	{
		[DataMember(Name = "title")]
		public string Title { get; set; }
		
		[DataMember(Name = "description")]
		public string Description { get; set; }
		
		[DataMember(Name = "type")]
		public TypeViewModel Type { get; set; }
		
		[DataMember(Name = "tags")]
		public ICollection<TagViewModel> Tags { get; set; }
		
		public async Task Update(MangaContext context, int mangaId)
		{
			var manga = await context.Mangas.FirstAsync(m => m.Id == mangaId);
			
			if (Title != null)
			{
				manga.Title = Title;
			}

			if (Description != null)
			{
				manga.Description = Description;
			}

			if (Type != null)
			{
				var type = await context.Types
					.FirstAsync(t => t.Id == Type.Id || t.Name == Type.Name);

				manga.Type = type;
			}

			if (Tags != null)
			{
				var mangaTagsToRemove = manga.MangaTags
					.Where(mt => !Tags.Any(t => t.Id == mt.Tag.Id || t.Name == mt.Tag.Name))
					.ToList();

				var mangaTagsToAdd = Tags
					.Where(tag => !manga.MangaTags.Any(t => t.Tag.Id == tag.Id || t.Tag.Name == tag.Name))
					.Select(tag => context.Tags.First(t => tag.Id == t.Id || tag.Name == t.Name))
					.Select(tag => new MangaTag(tag, manga))
					.ToList();

				context.MangaTags.RemoveRange(mangaTagsToRemove);
				await context.MangaTags.AddRangeAsync(mangaTagsToAdd);
			}
		}
	}
}