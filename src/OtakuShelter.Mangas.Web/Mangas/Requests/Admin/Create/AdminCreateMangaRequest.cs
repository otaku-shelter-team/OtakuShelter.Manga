using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Mangas
{
	[DataContract]
	public class AdminCreateMangaRequest
	{
		[DataMember(Name = "title")]
		public string Title { get; set; }

		[DataMember(Name = "description")]
		public string Description { get; set; }

		[DataMember(Name = "image")]
		public string Image { get; set; }

		[DataMember(Name = "type")]
		public TypeResponse Type { get; set; }

		[DataMember(Name = "tags")]
		public ICollection<TagResponse> Tags { get; set; }

		[DataMember(Name = "translators")]
		public ICollection<TranslatorResponse> Translators { get; set; }

		[DataMember(Name = "authors")]
		public ICollection<AuthorResponse> Authors { get; set; }

		public async ValueTask Create(MangasContext context)
		{
			var type = await context.Types
				.FirstAsync(t => t.Id == Type.Id);

			var tagsIds = Tags.Select(t => t.Id).ToList();

			var tags = await context.Tags
				.Where(tag => tagsIds.Contains(tag.Id))
				.ToListAsync();

			var translatorsIds = Translators.Select(t => t.Id).ToList();

			var translators = await context.Translators
				.Where(translator => translatorsIds.Contains(translator.Id))
				.ToListAsync();

			var authorsIds = Authors.Select(a => a.Id).ToList();

			var authors = await context.Authors
				.Where(author => authorsIds.Contains(author.Id))
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