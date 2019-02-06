using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class CreateMangaViewModel
	{
		[DataMember(Name = "title")]
		public string Title { get; set; }
		
		[DataMember(Name = "description")]
    public string Description { get; set; }
    
    [DataMember(Name = "type")]
    public TypeViewModel Type { get; set; }
    
    [DataMember(Name = "tags")]
    public ICollection<TagViewModel> Tags { get; set; }
		
		public async Task Create(MangaContext context)
		{
			var type = await context.Types
				.FirstAsync(t => t.Id == Type.Id || t.Name == Type.Name);
			
			var tags = await context.Tags
				.Where(tag => Tags.Any(t => t.Id == tag.Id || t.Name == tag.Name))
				.ToListAsync();

			var manga = new Manga
			{
				Title = Title,
				Description = Description,
				Type = type
			};

			await context.MangaTags
				.AddRangeAsync(tags.Select(tag => new MangaTag(tag, manga)));

			await context.Mangas.AddAsync(manga);
		}
	}
}