using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop
{
    public class Assortment
    {
        public List<Category> Categories { get; set; }
        public Assortment()
        {
            Categories = new List<Category>();
        }
        public void AddCategory(Category categories)
        {
            Categories.Add(categories);
        }
        public void RemoveCategory(Category categories)
        {
            Categories.Remove(categories);
        }
        public void ShowListCategories()
        {
            Console.WriteLine("Lista kategorii w Sklepie:");
            foreach (Category category in Categories)
            {
                Console.WriteLine("[*]    " + category.Name);
            }
            Console.WriteLine();
        }
        public Category SearchCategory(string name)
        {
            foreach (Category category in Categories)
            {
                if (category.SearchFoodProduct(name) != null)
                {
                    return category;
                }
                else if (category.SearchElectronicProduct(name) != null)
                {
                    return category;
                }
                else if (category.SearchBrandProduct(name) != null)
                {
                    return category;
                }
                else if (category.SearchProduct(name) != null)
                {
                    return category;
                }
            }
            return null;
        }
    }
}
