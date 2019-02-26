using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Manga
{
	[DataContract]
	public class AdminUpdateMangaRequest
	{
		[DataMember(Name = "title")]
		public string Title { get; set; }
		
		[DataMember(Name = "description")]
		public string Description { get; set; }
		
		[DataMember(Name = "type")]
		public TypeResponse Type { get; set; }
		
		[DataMember(Name = "tags")]
		public ICollection<TagResponse> Tags { get; set; }
		
		[DataMember(Name = "translators")] 
		public ICollection<TranslatorResponse> Translators { get; set; }
		
		[DataMember(Name = "authors")] 
		public ICollection<AuthorResponse> Authors { get; set; }
		
		public async ValueTask Update(MangaContext context, int mangaId)
		{
			var manga = await context.Mangas
				.Include(m => m.Tags)
				.Include(m => m.Translators)
				.Include(m => m.Authors)
				.FirstAsync(m => m.Id == mangaId);
			
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
				var type = await context.Types.FirstAsync(t => t.Id == Type.Id);

				manga.Type = type;
			}

			if (Tags != null)
			{
				var modelTagIds = Tags.Select(t => t.Id).ToList();
				var mangaTagIds = manga.Tags.Select(t => t.Tag.Id).ToList();

				var mangaTagsToRemove = mangaTagIds.Except(modelTagIds)
					.Select(tagId => manga.Tags.First(t => t.Tag.Id == tagId))
					.ToList();

				var mangaTagsToAdd = modelTagIds.Except(mangaTagIds)
					.Select(tagId => context.Tags.First(t => t.Id == tagId))
					.Select(tag => new MangaTag(tag, manga))
					.ToList();

				context.MangaTags.RemoveRange(mangaTagsToRemove);
				await context.MangaTags.AddRangeAsync(mangaTagsToAdd);
			}

			if (Translators != null)
			{
				var modelTranslatorIds = Translators.Select(t => t.Id).ToList();
				var mangaTranslatorIds = manga.Translators.Select(t => t.Translator.Id).ToList();

				var mangaTranslatorsToRemove = mangaTranslatorIds.Except(modelTranslatorIds)
					.Select(translatorId => manga.Translators.First(t => t.Translator.Id == translatorId))
					.ToList();

				var mangaTranslatorsToAdd = modelTranslatorIds.Except(mangaTranslatorIds)
					.Select(translatorId => context.Translators.First(t => t.Id == translatorId))
					.Select(translator => new MangaTranslator(translator, manga))
					.ToList();
				
				context.MangaTranslators.RemoveRange(mangaTranslatorsToRemove);
				await context.MangaTranslators.AddRangeAsync(mangaTranslatorsToAdd);
			}
			
			if (Authors != null)
			{
				var modelAuthorIds = Authors.Select(t => t.Id).ToList();
				var mangaAuthorIds = manga.Authors.Select(t => t.Author.Id).ToList();

				var mangaAuthorsToRemove = mangaAuthorIds.Except(modelAuthorIds)
					.Select(authorId => manga.Authors.First(t => t.Author.Id == authorId))
					.ToList();

				var mangaAuthorsToAdd = modelAuthorIds.Except(mangaAuthorIds)
					.Select(authorId => context.Authors.First(t => t.Id == authorId))
					.Select(author => new MangaAuthor(author, manga))
					.ToList();
				
				context.MangaAuthors.RemoveRange(mangaAuthorsToRemove);
				await context.MangaAuthors.AddRangeAsync(mangaAuthorsToAdd);
			}
		}
	}
}