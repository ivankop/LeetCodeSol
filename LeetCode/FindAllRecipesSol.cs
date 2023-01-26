using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class FindAllRecipesSol
    {
        public IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies)
        {
            Dictionary<string, IList<string>> recipesDict = new Dictionary<string, IList<string>>();
            Queue<string> queue = new Queue<string>();
            for (int i = 0; i < recipes.Length; i++)
            {
                recipesDict.Add(recipes[i], ingredients[i]);
                queue.Enqueue(recipes[i]);
            }
            var suppList = supplies.ToList();
            var recList = recipes.ToList();
            List<string> res = new List<string>();
            
            while (res.Count < recipes.Length)
            {
                var recipe = queue.Dequeue();
                int count = 0;
                if (recipesDict[recipe].All(i => suppList.Contains(i)))
                {
                    res.Add(recipe);
                    suppList.Add(recipe);
                    count++;
                }
                else
                {
                    queue.Enqueue(recipe);
                }
                
                if (count == 0)
                {
                    break;
                }
            }
            
            return res;
        }
        Dictionary<string, bool> mem = new Dictionary<string, bool>();
        public IList<string> FindAllRecipes2(string[] recipes, IList<IList<string>> ingredients, string[] supplies)
        {
            Dictionary<string, IList<string>> recipesDict = new Dictionary<string, IList<string>>();            
            for (int i = 0; i < recipes.Length; i++)
            {
                recipesDict.Add(recipes[i], ingredients[i]);                
            }
            var suppList = supplies.ToList();
            // var recList = recipes.ToList();
            List<string> res = new List<string>();
            foreach (var item in recipes)
            {
                if (FindBaseSupplies(item, recipesDict, suppList))
                {
                    res.Add(item);
                }
            }

            return res;
        }

        private bool FindBaseSupplies(string recipe, Dictionary<string, IList<string>> ingredientsDict, List<string> suppliesList)
        {
            if (mem.ContainsKey(recipe))
            {
                return mem[recipe];
            }
            mem[recipe] = false;
            bool res = true;
            if (!ingredientsDict.ContainsKey(recipe))
            {
                res = false;
            }
            else
            {
                foreach (var item in ingredientsDict[recipe])
                {
                    if (!suppliesList.Contains(item) && !FindBaseSupplies(item, ingredientsDict, suppliesList))
                    {
                        if (mem.ContainsKey(item))
                        {

                        }
                        res = false;
                        break;
                    }
                }
            }

            mem[recipe] = res;
            return res;
        }
    }
}
