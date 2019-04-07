using System.Collections.Generic;
using CsQuery;

namespace OtakuShelter.Mangas.MangaChan
{
    public static class PaginationParser
    {
        public static List<int> Parse(string htmlBody)
        {
            var cq = CQ.Create(htmlBody);
            var numbers = new List<int>();

            foreach (var domObj in cq.Find("#pagination span a"))
            {
                numbers.Add(int.Parse(domObj.FirstChild.NodeValue) * 20 - 20);
            }

            numbers.Insert(0, 0);
            return numbers;
        }
    }
}