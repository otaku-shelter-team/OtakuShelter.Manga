using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
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

            var response = "";
            var parser = new MangaParser();

//            var response = await client
//                .GetAsync("https://mangachan.me/catalog", cancellationToken).Result.Content
//                .ReadAsStringAsync();
//            var pagination = PaginationParser
//                .Parse(response);


//            response = await client
//                .GetAsync("https://mangachan.me/tags/", cancellationToken).Result.Content
//                .ReadAsStringAsync();
//            var allTags = new MangaParser {cq = CQ.Create(response)}.ParseAllTags();
//            await context.Tags.AddRangeAsync(allTags, cancellationToken);
//            
//            await context.SaveChangesAsync(cancellationToken);
//
//            response = await client
//                .GetAsync("https://mangachan.me/type/", cancellationToken).Result.Content
//                .ReadAsStringAsync();
//            var allTypes = new MangaParser {cq = CQ.Create(response)}.ParseAllTypes();
//            await context.Types.AddRangeAsync(allTypes, cancellationToken);
//            
//            await context.SaveChangesAsync(cancellationToken);
//
//            response = await client
//                .GetAsync("https://mangachan.me/mangaka/", cancellationToken).Result.Content
//                .ReadAsStringAsync();
//            var allAuthors = await new MangaParser {cq = CQ.Create(response)}.ParseAllAuthors();
//            await context.Authors.AddRangeAsync(allAuthors, cancellationToken);
//            
//            await context.SaveChangesAsync(cancellationToken);
//
//            response = await client
//                .GetAsync("https://mangachan.me/translation/", cancellationToken).Result.Content
//                .ReadAsStringAsync();
//            var allTranslators = await new MangaParser {cq = CQ.Create(response)}.ParseAllTranslators();
//            await context.Translators.AddRangeAsync(allTranslators, cancellationToken);
//
//            await context.SaveChangesAsync(cancellationToken);

            response = await client
                .GetAsync("https://mangachan.me/catalog?offset=0", cancellationToken).Result.Content
                .ReadAsStringAsync();
            var mangaListUrLs = parser.ParseMangaList(response);

            var authors = context.Authors.ToList();
            var translators = context.Translators.ToList();
            var tags = context.Tags.ToList();

            foreach (var mangaListUrl in mangaListUrLs)
            {
                response = await client
                    .GetAsync(mangaListUrl, cancellationToken).Result.Content
                    .ReadAsStringAsync();

                parser = new MangaParser
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

                var description = parser.ParseDescription();
                var image = parser.ParseImage();
                var type = parser.ParseType();
                var parsedAuthors = parser.ParseAuthors();
                var parsedTranslators = parser.ParseTranslators();
                var parsedTags = parser.ParseTags();
                var parsedChapters = parser.ParseChapters();

                var mangaAuthors = new List<Author>();

                foreach (var author in parsedAuthors)
                {
                    var containsAuthors = authors.Where(x => x.Name == author.Name).ToList();
                    if (containsAuthors.Count != 0)
                        mangaAuthors.AddRange(containsAuthors);
                    else
                        mangaAuthors.Add(author);
                }

                manga = new Manga
                {
                    Title = title,
                    Description = description,
                    Image = image,
                    Type = type,
                    Tags = parsedTags
                        .Select(tag =>
                            new MangaTag
                            {
                                Tag = tags.FirstOrDefault(x => x.Name == tag.Name)
                            }).ToList(),
                    Authors = mangaAuthors
                        .Select(author =>
                            new MangaAuthor
                            {
                                Author = author
                            }).ToList(),
                    Translators = parsedTranslators
                        .Select(translator =>
                            new MangaTranslator
                            {
                                Translator = translators.FirstOrDefault(x => x.Name == translator.Name)
                            }).ToList(),
                    Chapters = parsedChapters
                        .Select(chapter =>
                            new Chapter
                            {
                                Title = chapter.Result.Title,
                                UploadDate = chapter.Result.UploadDate,
                                Order = chapter.Result.Order,
                                Pages = chapter.Result.Pages
                            }).ToList()
                };

                context.Mangas.Add(manga);
                await context.SaveChangesAsync(cancellationToken);
                Console.WriteLine($"{title} done");
            }
        }
    }
}