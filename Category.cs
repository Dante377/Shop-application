using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop
{
    public class Category
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public List<BrandProduct> BrandProducts { get; set; }
        public List<FoodProduct> FoodProducts { get; set; }
        public List<ElectronicProduct> ElectronicProducts { get; set; }


        public Category(string name)
        {
            Name = name;
            Products = new List<Product>();
            BrandProducts = new List<BrandProduct>();
            FoodProducts = new List<FoodProduct>();
            ElectronicProducts= new List<ElectronicProduct>();
        }
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
        public void AddElectroProduct (ElectronicProduct productelectro)
        {
            ElectronicProducts.Add(productelectro);
        }
        public void AddBrandProduct(BrandProduct brandproduct)
        {
            BrandProducts.Add(brandproduct);
        }
        public void AddFoodProduct(FoodProduct foodproduct)
        {
            FoodProducts.Add(foodproduct);
        }
        public void RemoveProduct(string name)
        {
            Product product = Products.Find(p => p.Name == name);
            Products.Remove(product);
        }
        public void RemoveElectroProduct(string name)
        {
            ElectronicProduct product = ElectronicProducts.Find(p => p.Name == name);
            ElectronicProducts.Remove(product);
        }
        public void RemoveBrandProduct (string name)
        {
            BrandProduct product = BrandProducts.Find(p => p.Name == name);
            BrandProducts.Remove(product);
        }
        public void RemoveFoodProduct (string name)
        {
            FoodProduct product = FoodProducts.Find(p => p.Name == name);
            FoodProducts.Remove(product);
        }
        public Product SearchProduct(string name)
        {
            return Products.Find(p => p.Name == name);
        }
        public FoodProduct SearchFoodProduct (string name)
        {
            return FoodProducts.Find(p => p.Name == name);
        }
        public BrandProduct SearchBrandProduct (string name)
        {
            return BrandProducts.Find(p => p.Name == name);
        }
        public ElectronicProduct SearchElectronicProduct (string name)
        {
            return ElectronicProducts.Find(p => p.Name == name);
        }
        public void ShowListCategories()
        {
            Console.WriteLine($"Lista produktów w kategorii {Name}: ");
            Console.WriteLine();
            foreach (ElectronicProduct productelectro in ElectronicProducts)
            {
                Console.WriteLine($"[*] {productelectro.Name}");
                Console.WriteLine($"    Moc urzadzenia: {productelectro.Power}");
                Console.WriteLine($"    Data produkcji: {productelectro.ProductionDate}");
                Console.WriteLine($"    CENA: {productelectro.Price} zl");
                Console.WriteLine();
            }
            foreach (BrandProduct brandproduct in BrandProducts)
            {
                Console.WriteLine($"[*] {brandproduct.Name}");
                Console.WriteLine($"    Marka: {brandproduct.Brand}");
                Console.WriteLine($"    CENA: {brandproduct.Price} zl");
                Console.WriteLine();
            }
            foreach (FoodProduct foodProduct in FoodProducts)
            {
                Console.WriteLine($"[*] {foodProduct.Name}");
                Console.WriteLine($"    Data waznosci: {foodProduct.ExpirationDate}");
                Console.WriteLine($"    Kalorie: {foodProduct.Calories} Kcal");
                Console.WriteLine($"    CENA: {foodProduct.Price} zl");
                Console.WriteLine();
            }
            foreach (Product product in Products)
            {
                Console.WriteLine($"[*] {product.Name}");
                Console.WriteLine($"    CENA: {product.Price} zl");
                Console.WriteLine();
            }
        }
    }
}
