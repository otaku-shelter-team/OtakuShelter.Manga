using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CsQuery;
using CsQuery.ExtensionMethods.Internal;

namespace OtakuShelter.Mangas.MangaChan
{
    public class MangaParser
    {
        public CQ cq { get; set; }

//                AnotherTitleName = table.Filter((x, index) => index == 0).Text(),
//                Status = table[3].InnerText,
//                MangaUrl = cq.Find(".name_row .title_top_a")[0].GetAttribute("href"),
        public List<Author> ParseAuthors()
        {
            var table = cq
                .Find(".mangatitle .item2");
            return table
                .Filter((x, index) => index == 2).Find("a")
                .Where(x => x.FirstChild != null)
                .Select(x => new Author {Name = x.FirstChild.NodeValue}).ToList();
        }

        public string ParseDescription()
        {
            return cq
                .Find("#description")[0].InnerText
                .Replace("Прислать описание", "").Trim();
        }

        public string ParseImage()
        {
            return cq
                .Find("#cover")[0]
                .GetAttribute("src");
        }

        public Type ParseType()
        {
            var table = cq
                .Find(".mangatitle .item2");
            return table
                .Filter((x, index) => index == 1).Find("a")
                .Where(x => x.FirstChild != null)
                .Select(x => new Type {Name = x.FirstChild.NodeValue}).FirstOrDefault();
        }

        public string ParseTitle()
        {
            return cq
                .Find(".name_row .title_top_a")[0].InnerText;
        }

        public List<Translator> ParseTranslators()
        {
            var table = cq
                .Find(".mangatitle .item2");
            return table
                .Filter((x, index) => index == 6).Find("a")
                .Where(x => x.FirstChild != null)
                .Select(x => new Translator {Name = x.FirstChild.NodeValue}).ToList();
        }

        public List<Tag> ParseTags()
        {
            var table = cq
                .Find(".mangatitle .item2");
            return table
                .Filter((x, index) => index == 5).Find("a")
                .Where(x => x.FirstChild != null)
                .Select(x => new Tag {Name = x.FirstChild.NodeValue}).ToList();
        }

        public List<Task<Chapter>> ParseChapters()
        {
            return cq
                .Find(".table_cha tr")
                .Filter(x =>
                    x.GetAttribute("class") == "no_zaliv" || x.GetAttribute("class") == "zaliv")
                .Select(async x => new Chapter
                {
                    Title = x.FirstChild.FirstChild.FirstChild.InnerText,
                    UploadDate = Convert.ToDateTime(x.LastChild.FirstChild.InnerText),
                    Pages = await ParsePages(
                        "https://mangachan.me" +
                        x.FirstChild.FirstChild.FirstChild.GetAttribute("href"))
                }).ToList();
        }

        public List<Tag> ParseAllTags()
        {
            return cq
                .Find(".news")
                .Children()
                .Select(x =>
                {
                    var builder = new StringBuilder(x.InnerText);
                    builder[0] = builder[0].ToUpper();
                    builder.Replace("_", " ");
                    return new Tag
                    {
                        Name = builder.ToString()
                    };
                }).ToList();
        }

        public List<Type> ParseAllTypes()
        {
            return cq
                .Find(".series_wrap h2")
                .Children()
                .Select(x => new Type
                {
                    Name = x.InnerText.Replace("\n", "")
                })
                .Where(x => x.Name != "").ToList();
        }

        public async Task<List<Author>> ParseAllAuthors()
        {
            var client = new HttpClient();
            var pagination = cq
                .Find("#pagination span a")
                .Select(x => (int.Parse(x.InnerText) - 1) * 300)
                .ToList();
            pagination.Insert(0, 0);
            var authors = new List<Author>();
            foreach (var i in pagination)
            {
                var page = await client
                    .GetAsync($"https://mangachan.me/mangaka/?offset={i}").Result.Content
                    .ReadAsStringAsync();
                var localcq = CQ.Create(page);
                var pageAuthors = localcq.Find(".series_wrap h2")
                    .Children()
                    .Select(x => new Author
                    {
                        Name = x.InnerText.Replace("\n", "")
                    })
                    .Where(x => x.Name != "").ToList();
                authors.AddRange(pageAuthors);
            }

            return authors;
        }

        public async Task<List<Translator>> ParseAllTranslators()
        {
            var client = new HttpClient();
            var pagination = cq
                .Find("#pagination span a")
                .Select(x => (int.Parse(x.InnerText) - 1) * 300)
                .ToList();
            pagination.Insert(0, 0);
            var translators = new List<Translator>();
            foreach (var i in pagination)
            {
                var page = await client
                    .GetAsync($"https://mangachan.me/translation/?offset={i}").Result.Content
                    .ReadAsStringAsync();
                var localcq = CQ.Create(page);
                var pageTranslators = localcq.Find(".series_wrap h2")
                    .Children()
                    .Select(x => new Translator
                    {
                        Name = x.InnerText.Replace("\n", "").Replace("\r", "")
                    })
                    .Where((x, index) => x.Name != "")
                    .Where((x, index) => index % 2 == 0)
                    .ToList();
                translators.AddRange(pageTranslators);
            }

            return translators;
        }

        private static async Task<List<Page>> ParsePages(string getAttribute)
        {
            var client = new HttpClient();
            var response = await client
                .GetAsync(getAttribute).Result.Content
                .ReadAsStringAsync();
            var localcq = CQ.Create(response);
            var current = localcq.Find("center").Prev().Text();
            var firstIndex = current.IndexOf("\"fullimg\":[", StringComparison.Ordinal) + 11;
            var secondIndex = current.IndexOf(",]", StringComparison.Ordinal);
            var stringArray = current.Substring(firstIndex, secondIndex - firstIndex).Split(",");
            var pages = stringArray.Select(s => new Page
            {
                Image = s.Replace("\"", "")
            }).ToList();
            return pages;
        }
    }
}