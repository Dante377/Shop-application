using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
    public class FoodProduct : Product
    {
        public string ExpirationDate { get; set; }
        public int Calories { get; set; }

        public FoodProduct(string name, double price, string expirationDate, int calories): base (name, price)
        {
            ExpirationDate = expirationDate;
            Calories = calories;
        }
    }
    public class BrandProduct : Product
    {
        public string Brand { get; set; }

        public BrandProduct(string name, double price, string brand) : base (name,price)
        {
            Brand = brand;
        }

    }
    public class ElectronicProduct : Product
    {
        public int Power { get; set; }
        public string ProductionDate { get; set; }

        public ElectronicProduct(string name, double price, int power, string productiondate) : base (name, price)
        {
            Power = power;
            ProductionDate = productiondate;
        }
    }
    public class Receipt 
    {
        public string IsPaid {get; set;}
        public int ReceiptID { get; set;}
        public Receipt (string ispaid, int receiptid)          
        {
            IsPaid = ispaid;
            ReceiptID = receiptid;
        }
        public void Print (Order order)
        {  
            Console.WriteLine($"========= PARAGON ZAMOWIENIA NR {order.ID} ==========");
            Console.WriteLine($"Czy jest zaplacone: {IsPaid}\n");
            foreach (ElectronicProduct product in order.ElectronicProducts)
            {
                Console.WriteLine($"[*] {product.Name} {product.Price} zl");
            }
            foreach (FoodProduct product in order.FoodProducts)
            {
                Console.WriteLine($"[*] {product.Name} {product.Price} zl");
            }
            foreach (BrandProduct product in order.BrandProducts)
            {
                Console.WriteLine($"[*] {product.Name} {product.Price} zl");
            }
            foreach (Product product in order.Products)
            {
                Console.WriteLine($"[*] {product.Name} {product.Price} zl");
            }
            Console.WriteLine($"\nRazem: { order.TotalPrice} zl ");
            Console.WriteLine("============================================");
        }
    }
    class Invoice 
    {
        public string CompanyName { get; set; }
        public string NIP { get; set; }
        public int InvoiceID { get; set; }

        public Invoice (string companyname, string nip, int invoiceid)
        {
            CompanyName = companyname;
            NIP = nip;
            InvoiceID= invoiceid;
        }

        public void Print(Order order)
        {
            Console.WriteLine($"========= FAKTURA ZAMOWIENIA NR {order.ID} ==========");
            Console.WriteLine($"Nazwa firmy: {CompanyName} ");
            Console.WriteLine($"NIP: {NIP} \n");
            foreach (ElectronicProduct product in order.ElectronicProducts)
            {
                Console.WriteLine($"[*] {product.Name} {product.Price} zl");
            }
            foreach (FoodProduct product in order.FoodProducts)
            {
                Console.WriteLine($"[*] {product.Name} {product.Price} zl");
            }
            foreach (BrandProduct product in order.BrandProducts)
            {
                Console.WriteLine($"[*] {product.Name} {product.Price} zl");
            }
            foreach (Product product in order.Products)
            {
                Console.WriteLine($"[*] {product.Name} {product.Price} zl");
            }
            Console.WriteLine($"\nRazem: {order.TotalPrice} zl ");
            Console.WriteLine("============================================");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 
            App app = new App();

            bool Loop = true;

            app.AddProductToShopStart();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Wersja BETA");
            Console.CursorTop = 10;
            Console.CursorLeft = 50;
            Console.WriteLine("Witaj w sklepie\n");

            #endregion

            while (Loop == true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    app.Display();
                    Console.Write("Opcja: ");
                    int choice = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    switch (choice)
                    {
                        case 1:
                            app.AddCategory();
                            break;
                        case 2:
                            app.DisplayAssortment();
                            app.DeleteCategory();
                            break;
                        case 3:
                            app.AddProductToShop();
                            break;
                        case 4:
                            app.DeleteProduct();
                            break;
                        case 5:
                            app.DisplayProductsInCategories();
                            break;
                        case 6:
                            app.DisplayAssortment();
                            break;
                        case 7:
                            app.FindProduct(); 
                            break;
                        case 8:
                            app.DisplayProductsInCategories();
                            app.CreateOrder(); 
                            break;
                        case 9:
                            app.DisplayOrders();
                            break;
                        case 10:
                            app.ModifyOrder();
                            break;
                        case 11:
                            app.DeleteOrder();
                            break;
                        case 12:
                            app.CreateReceipt();
                            break;
                        case 13:
                            app.DisplayReceipts();
                            break;
                        case 14:
                            app.DeleteReceipt();
                            break;
                        case 0:
                            Console.WriteLine("Program konczy dzialanie");
                            Loop = false;
                            break;
                        default: Console.WriteLine("Wybrana opcja nie istnieje\n"); break;
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine("Podaj wlasciwa opcje. " + error.Message + "\n");
                }
            }
        }
    }
}
