using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class SuggestedProductsSol
    {
        public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {
            IList<IList<string>> suggestProduct = new List<IList<string>>();
            products = products.OrderBy(p => p).ToArray();
            for (int i = 1; i <= searchWord.Length; i++)
            {
                string keyword = searchWord.Substring(0, i);
                var prods = products.Where(p => p.StartsWith(keyword)).Take(3).ToList();
                suggestProduct.Add(prods);
            }

            return suggestProduct;
        }
    }
}
