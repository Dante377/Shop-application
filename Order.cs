using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Order
    {
        public int ID { get; set; }
        public List<Product> Products { get; set; }
        public List<ElectronicProduct> ElectronicProducts { get; set; }
        public List <FoodProduct> FoodProducts { get; set; }
        public List<BrandProduct> BrandProducts { get; set; }
        public double TotalPrice { get; set; }

        public Order(int id) 
        {
            ID= id;
            Products = new List<Product>();
            TotalPrice = 0;
            BrandProducts = new List<BrandProduct>();
            FoodProducts = new List<FoodProduct>();
            ElectronicProducts = new List<ElectronicProduct>();
        }
        public void AddProduct(Product product)
        {
            Products.Add(product);
            TotalPrice += product.Price;
        }
        public void AddElectroProduct (ElectronicProduct product)
        {
            ElectronicProducts.Add(product);
            TotalPrice += product.Price;
        }
        public void AddFoodProduct(FoodProduct product)
        {
            FoodProducts.Add(product);
            TotalPrice += product.Price;
        }
        public void AddBrandProduct (BrandProduct product)
        {
            BrandProducts.Add(product);
            TotalPrice += product.Price;
        }
        public void RemoveProduct(string name)
        {
            Product product = Products.Find(p => p.Name== name);
            Products.Remove(product);
            TotalPrice -= product.Price;
        }
        public void RemoveElectroProduct(string name)
        {
            ElectronicProduct product = ElectronicProducts.Find(p => p.Name == name);
            ElectronicProducts.Remove(product);
            TotalPrice -= product.Price;
        }
        public void RemoveBrandProduct(string name)
        {
            BrandProduct product = BrandProducts.Find(p => p.Name == name);
            BrandProducts.Remove(product);
            TotalPrice -= product.Price;
        }
        public void RemoveFoodProduct(string name)
        {
            FoodProduct product = FoodProducts.Find(p => p.Name == name);
            FoodProducts.Remove(product);
            TotalPrice -= product.Price;
        }
        public Product SearchProduct(string name)
        {
            return Products.Find(p=> p.Name==name);
        }
        public FoodProduct SearchFoodProduct(string name)
        {
            return FoodProducts.Find(p => p.Name == name);
        }
        public BrandProduct SearchBrandProduct(string name)
        {
            return BrandProducts.Find(p => p.Name == name);
        }
        public ElectronicProduct SearchElectronicProduct(string name)
        {
            return ElectronicProducts.Find(p => p.Name == name);
        }

    }
}
