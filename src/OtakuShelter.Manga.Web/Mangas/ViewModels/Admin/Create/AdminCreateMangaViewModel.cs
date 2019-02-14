using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class AdminCreateMangaViewModel
	{
		[DataMember(Name = "title")]
		public string Title { get; set; }
		
		[DataMember(Name = "description")]
    public string Description { get; set; }

    [DataMember(Name = "image")]
    public string Image { get; set; }
    
    [DataMember(Name = "type")]
    public TypeViewModel Type { get; set; }
    
    [DataMember(Name = "tags")]
    public ICollection<TagViewModel> Tags { get; set; }

    [DataMember(Name = "translators")]
    public ICollection<TranslatorViewModel> Translators { get; set; }
    
    [DataMember(Name = "authors")]
    public ICollection<AuthorViewModel> Authors { get; set; }
		
		public async Task Create(MangaContext context)
		{
			var type = await context.Types
				.FirstAsync(t => t.Id == Type.Id);
			
			var tags = await context.Tags
				.Where(tag => Tags.Any(t => t.Id == tag.Id))
				.ToListAsync();

			var translators = await context.Translators
				.Where(translator => Translators.Any(t => t.Id == translator.Id))
				.ToListAsync();
			
			var authors = await context.Authors
				.Where(translator => Authors.Any(t => t.Id == translator.Id))
				.ToListAsync();

			var manga = new Manga
			{
				Title = Title,
				Description = Description,
				Image = Image,
				Type = type
			};

			await context.MangaTags
				.AddRangeAsync(tags.Select(tag => new MangaTag(tag, manga)));

			await context.MangaTranslators
				.AddRangeAsync(translators.Select(translator => new MangaTranslator(translator, manga)));
			
			await context.MangaAuthors
				.AddRangeAsync(authors.Select(author => new MangaAuthor(author, manga)));

			await context.Mangas.AddAsync(manga);
		}
	}
}