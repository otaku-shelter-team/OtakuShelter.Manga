using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CsQuery;
using Microsoft.EntityFrameworkCore;
using OtakuShelter.Mangas.MangaChan;
using YamlDotNet.Core;

namespace OtakuShelter.Mangas
{
    public class DefaultMangaParser : IMangaParser
    {
        private readonly MangasContext context;
        private HttpClient client = new HttpClient();

        public DefaultMangaParser(MangasContext context)
        {
            this.context = context;
        }

        public async Task Parse(CancellationToken cancellationToken)
        {
            return;
//            var firstManga = await context.Mangas.FirstAsync(cancellationToken);
//            var htmlBody = await client
//                .GetAsync("https://mangachan.me/catalog", cancellationToken).Result.Content
//                .ReadAsStringAsync();
//            var pagination = PaginationParser
//                .Parse(htmlBody);

            var response = await client
                .GetAsync("https://mangachan.me/tags/", cancellationToken).Result.Content
                .ReadAsStringAsync();
            var allTags = new MangaParser {cq = CQ.Create(response)}.ParseAllTags();
            response = await client
                .GetAsync("https://mangachan.me/type/", cancellationToken).Result.Content
                .ReadAsStringAsync();
            var allTypes = new MangaParser {cq = CQ.Create(response)}.ParseAllTypes();
            response = await client
                .GetAsync("https://mangachan.me/mangaka/", cancellationToken).Result.Content
                .ReadAsStringAsync();
            var allAuthors = await new MangaParser {cq = CQ.Create(response)}.ParseAllAuthors();
            response = await client
                .GetAsync("https://mangachan.me/translation/", cancellationToken).Result.Content
                .ReadAsStringAsync();
            var allTranslators = await new MangaParser {cq = CQ.Create(response)}.ParseAllTranslators();


            
            
            
            
            
            
            
            
            
            
            
            
            

            response = await client
                .GetAsync("https://mangachan.me/manga/8321-000000-ultra-black.html", cancellationToken).Result.Content
                .ReadAsStringAsync();
            var parser = new MangaParser
            {
                cq = CQ.Create(response)
            };
            var title = parser.ParseTitle();
            var manga = await context.Mangas
                .Include(m => m.Chapters)
                .ThenInclude(c => c.Pages)
                .FirstOrDefaultAsync((x) => x.Title == title, cancellationToken: cancellationToken);

            if (manga != null)
            {
                return;
            }

            var bdpages = context.Pages.Include(page => page);

            var description = parser.ParseDescription();
            var image = parser.ParseImage();
            var type = parser.ParseType();
            var parsedAuthors = parser.ParseAuthors();
            var parsedTranslators = parser.ParseTranslators();
            var parsedTags = parser.ParseTags();
            var parsedChapters = parser.ParseChapters();

            var authors = new List<Author>();
            var translators = new List<Translator>();
            var tags = new List<Tag>();
            var chapters = new List<Chapter>();

            foreach (var parsedAuthor in parsedAuthors)
            {
                var some = await context.Authors.FirstOrDefaultAsync(author => author.Equals(parsedAuthor));
                if (some == null)
                {
                    context.Authors.Add(parsedAuthor);
                    authors.Add(parsedAuthor);
                }
                else
                {
                    authors.Add(some);
                }
            }

            foreach (var parsedTranslator in parsedTranslators)
            {
                var some = await context.Translators.FirstOrDefaultAsync(translatore =>
                    translatore.Equals(parsedTranslator));
                if (some == null)
                {
                    context.Translators.Add(parsedTranslator);
                    translators.Add(parsedTranslator);
                }
                else
                {
                    translators.Add(some);
                }
            }

            foreach (var parsedTag in parsedTags)
            {
                var some = await context.Tags.FirstOrDefaultAsync(tag => tag.Equals(parsedTag));
                if (some == null)
                {
                    context.Tags.Add(parsedTag);
                    tags.Add(parsedTag);
                }
                else
                {
                    tags.Add(some);
                }
            }

            foreach (var parsedChapter in parsedChapters)
            {
                var some = await context.Chapters.FirstOrDefaultAsync(tag => tag.Equals(parsedChapter));
                if (some == null)
                {
                    context.Chapters.Add(parsedChapter);
                    chapters.Add(parsedChapter);
                }
                else
                {
                    chapters.Add(some);
                }
            }

            manga = new Manga
            {
                Title = title,
                Description = description,
                Image = image,
                Type = type
            };

            manga.Authors = authors.Select(author => new MangaAuthor(author, manga)).ToList();
            manga.Translators = translators.Select(translator => new MangaTranslator(translator, manga)).ToList();
            manga.Tags = tags.Select(tag => new MangaTag(tag, manga)).ToList();

            context.Mangas.Add(manga);
//            await context.SaveChangesAsync();
        }
    }
}