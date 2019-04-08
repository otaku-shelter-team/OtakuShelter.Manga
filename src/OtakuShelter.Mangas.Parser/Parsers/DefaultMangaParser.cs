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
//            return;

            var response = "";
            var parser = new MangaParser();
            var authors = context.Authors.ToList();
//            var translators = context.Translators.ToList();
            var tags = context.Tags.ToList();
            var types = context.Types.ToList();
            var mangas = context.Mangas.ToList();

            #region parse Tags, Translators, Types, Authors

            response = await client
                .GetAsync("https://mangachan.me/tags/", cancellationToken).Result.Content
                .ReadAsStringAsync();
            parser.cq = CQ.Create(response);
            var allTags = parser.ParseAllTags();
            var changesTags = allTags.Where(x => tags.All(y => x.Name != y.Name)).ToList();
            if (changesTags.Count != 0)
            {
                await context.Tags.AddRangeAsync(changesTags, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
                tags = context.Tags.ToList();
            }

            response = await client
                .GetAsync("https://mangachan.me/type/", cancellationToken).Result.Content
                .ReadAsStringAsync();
            parser.cq = CQ.Create(response);
            var allTypes = parser.ParseAllTypes();
            var changesTypes = allTypes.Where(x => types.All(y => x.Name != y.Name)).ToList();
            if (changesTypes.Count != 0)
            {
                await context.Types.AddRangeAsync(changesTypes, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
                types = context.Types.ToList();
            }

//
//            response = await client
//                .GetAsync("https://mangachan.me/mangaka/", cancellationToken).Result.Content
//                .ReadAsStringAsync();
//            var allAuthors = await new MangaParser {cq = CQ.Create(response)}.ParseAllAuthors();
//            await context.Authors.AddRangeAsync(allAuthors, cancellationToken);
//            await context.SaveChangesAsync(cancellationToken);

//            response = await client
//                .GetAsync("https://mangachan.me/translation/", cancellationToken).Result.Content
//                .ReadAsStringAsync();
//            var allTranslators = await new MangaParser {cq = CQ.Create(response)}.ParseAllTranslators();
//            var changesTranslators = translators.Where(x => allTranslators.All(y => x.Name != y.Name)).ToList();
//            if (changesTypes.Count != 0)
//            {
//                await context.Translators.AddRangeAsync(changesTranslators, cancellationToken);
//                await context.SaveChangesAsync(cancellationToken);
//                translators = context.Translators.ToList();
//            }

            #endregion


            response = await client
                .GetAsync("https://mangachan.me/catalog", cancellationToken).Result.Content
                .ReadAsStringAsync();
            var pagination = PaginationParser
                .Parse(response);

            foreach (var page in pagination)
            {
                response = await client
                    .GetAsync($"https://mangachan.me/catalog?offset={page}", cancellationToken).Result.Content
                    .ReadAsStringAsync();
                var mangaListUrLs = parser.ParseMangaList(response);

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
                    if (mangas.Any(x => x.Title == title))
                    {
                        continue;
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

                    var manga = new Manga
                    {
                        Title = title,
                        Description = description,
                        Image = image,
                        Type = types.FirstOrDefault(x => x.Name == type.Name),
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
                                    Author = context.Authors.FirstOrDefault(x => x.Name == author.Name) ?? author
                                }).ToList(),
                        Translators = parsedTranslators
                            .Select(translator =>
                                new MangaTranslator
                                {
                                    Translator = context.Translators.FirstOrDefault(x => x.Name == translator.Name) ??
                                                 translator
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
}