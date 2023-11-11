using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shop
{
    public class App
    {
        private Assortment Assortment;

        private List<Order> Orders;
        private List<Invoice> Invoices;
        private List<Receipt> Receipts;

        public App()
        {
            Assortment = new Assortment();
            Orders = new List<Order>();
            Invoices= new List<Invoice>();
            Receipts= new List<Receipt>();
        }
        public void Display()
        {
            Console.WriteLine("Wybierz odpowiednia opcje: \n");
            Console.WriteLine("\t Opcje dla pracownikow: ");
            Console.WriteLine("\t\t[1] Dodaj kategorie do sklepu "); 
            Console.WriteLine("\t\t[2] Usun kategorie ze sklepu "); 
            Console.WriteLine("\t\t[3] Dodaj produkt do sklepu i do kategorii "); 
            Console.WriteLine("\t\t[4] Usun produkt "); 
            Console.WriteLine("\t\t[0] Wyjdz ze sklepu\n"); 
            Console.WriteLine("\t Opcje dla klientow: "); 
            Console.WriteLine("\t\t[5] Wyswietl asortyment sklepu z podzialem na kategorie"); 
            Console.WriteLine("\t\t[6] Wyswietl same Kategorie"); 
            Console.WriteLine("\t\t[7] Wyszukaj produkt "); 
            Console.WriteLine("\t\t[8] Stworz zamowienie"); 
            Console.WriteLine("\t\t[9] Pokaz zamowienia"); 
            Console.WriteLine("\t\t[10] Modyfikuj zamowienie"); 
            Console.WriteLine("\t\t[11] Usun zamowienie"); 
            Console.WriteLine("\t\t[12] Generuj rachunek"); 
            Console.WriteLine("\t\t[13] Pokaz rachunki");
            Console.WriteLine("\t\t[14] Usun rachunek");
            Console.WriteLine("\t\t[0] Wyjdz ze sklepu\n"); 
        }
        public void AddProductToShopStart()
        {
            Category category = new Category("Produkt spozywczy");
            Category category2 = new Category("Produkt elektroniczny");
            Category category3 = new Category("Produkt markowy");
            Assortment.AddCategory(category);
            Assortment.AddCategory(category2);
            Assortment.AddCategory(category3);
            category.AddFoodProduct(new FoodProduct("pepsi puszka 250 ml", 4, "05/05/2023", 600));
            category.AddFoodProduct(new FoodProduct("fanta puszka 250 ml", 3.5, "06/11/2023", 518));
            category.AddFoodProduct(new FoodProduct("gruszka", 2, "05/01/2023", 57));
            category.AddFoodProduct(new FoodProduct("jablko", 2, "19/01/2023", 52));
            category2.AddElectroProduct(new ElectronicProduct("pralka", 800, 2000, "23/10/2019"));
            category2.AddElectroProduct(new ElectronicProduct("TV", 1500, 50, "11/07/2021"));
            category2.AddElectroProduct(new ElectronicProduct("ekspres do kawy", 1000, 400, "12/12/2022"));
            category2.AddElectroProduct(new ElectronicProduct("radio", 200, 5, "11/07/2021"));
            category3.AddBrandProduct(new BrandProduct("czapka", 70, "Nike"));
            category3.AddBrandProduct(new BrandProduct("kurtka", 800, "The North Face"));
            category3.AddBrandProduct(new BrandProduct("krem do rak", 10, "Dove"));
            category3.AddBrandProduct(new BrandProduct("pasta do zebow", 6, "Colgate"));
        }
        public void AddProductToShop()
        {
            string name, expiration_date, production_date, brand;
            double price;
            int calories, power;

            Console.Write("Podaj kategorie produktu ktory chcesz dodac: ");
            string CategoryName = Console.ReadLine();
            Category category = Assortment.Categories.Find(c => c.Name == CategoryName);

            if (category == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Taka kategoria nie istnieje!");
                Console.WriteLine("WRACAM DO MENU");
                Thread.Sleep(1000);
            }
            else
            {
                Console.Write("Podaj nazwe produktu ktory chcesz dodac: ");
                name = Console.ReadLine();
                try
                {
                    if (category.Name == "Produkt spozywczy" && Assortment.SearchCategory(name) == null)
                    {
                        Console.Write("Podaj cene produktu: ");
                        price = double.Parse(Console.ReadLine());
                        Console.Write("Podaj termin waznosci produktu: ");
                        expiration_date = Console.ReadLine();
                        Console.Write("Podaj kalorie produktu: ");
                        calories = int.Parse(Console.ReadLine());

                        FoodProduct foodproduct = new FoodProduct(name, price, expiration_date, calories);
                        category.AddFoodProduct(foodproduct);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Pomyslnie dodano {name} do kategorii {category.Name}");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else if (category.Name == "Produkt elektroniczny" && Assortment.SearchCategory(name) == null)
                    {
                        Console.Write("Podaj cene produktu: ");
                        price = double.Parse(Console.ReadLine());
                        Console.Write("Podaj moc urzadzenia: ");
                        power = int.Parse(Console.ReadLine());
                        Console.Write("podaj date produkcji produktu: ");
                        production_date = Console.ReadLine();

                        ElectronicProduct productelectro = new ElectronicProduct(name, price, power, production_date);
                        category.AddElectroProduct(productelectro);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Pomyslnie dodano {name} do kategorii {category.Name}");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else if (category.Name == "Produkt markowy" && Assortment.SearchCategory(name) == null)
                    {
                        Console.Write("Podaj cene produktu: ");
                        price = double.Parse(Console.ReadLine());
                        Console.Write("Podaj marke produktu: ");
                        brand = Console.ReadLine();

                        BrandProduct brandproduct = new BrandProduct(name, price, brand);
                        category.AddBrandProduct(brandproduct);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Pomyslnie dodano {name} do kategorii {category.Name}");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else if (Assortment.SearchCategory(name)==null)
                    {
                        Console.Write("Podaj cene produktu: ");
                        price = double.Parse(Console.ReadLine());
                        Product product = new Product(name, price);
                        category.AddProduct(product);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Pomyslnie dodano {name} do kategorii {category.Name}");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Produkt o nazwie {name} już istnieje!");
                        Console.WriteLine("WRACAM DO MENU");
                        Thread.Sleep(1000);
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Podales bledna wartosc!");
                    Console.WriteLine("WRACAM DO MENU");
                    Thread.Sleep(1000);
                }
            }
        }
        public void AddCategory()
        {
            string Loop = "T";
            while (Loop == "T")
            {
                Console.Write("Podaj nazwe kategorii jaka chcesz dodac: ");
                string CategoryName = Console.ReadLine();
                Category category = Assortment.Categories.Find(k => k.Name == CategoryName);
                if (category == null)
                {
                    category = new Category(CategoryName);
                    Assortment.AddCategory(category);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Pomyslnie dodano kategorie do asortymentu sklepu");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Taka kategoria juz istnieje, podaj taka ktora nie istnieje!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                Console.Write("Czy chcesz dodac kolejna kategorie? [T/n]: ");
                Loop = Console.ReadLine();
                if (Loop == "n")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("WRACAM DO MENU");
                    Thread.Sleep(1000);
                }
                if (Loop != "T" && Loop != "n")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Podales zla wartosc!");
                    Console.WriteLine("WRACAM DO MENU");
                    Thread.Sleep(1000);
                }
            }
            Console.WriteLine();
        }
        public void DisplayAssortment()
        {
            Assortment.ShowListCategories();
        }
        public void DisplayProductsInCategories()
        {
            foreach (Category category in Assortment.Categories)
            {
                category.ShowListCategories();
            }
        }
        public void DeleteCategory()
        {
            Console.Write("Podaj nazwe kategorii ktora chcesz usunac: ");
            string CategoryName= Console.ReadLine();
            Category category = Assortment.Categories.Find(k => k.Name == CategoryName);
            if (category == null )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Kategoria ktora probujesz usunac nie istnieje!");
                Console.WriteLine("WRACAM DO MENU");
                Thread.Sleep(2000);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nPomyslnie usnieto Kategorie o nazwie: {category.Name}\n");
                Assortment.RemoveCategory(category);
            }
        }
        public void DeleteProduct()
        {
            Console.Write("Podaj nazwe produktu ktory chcesz usunac: ");
            string productname= Console.ReadLine();
            Category category = Assortment.SearchCategory(productname);
            if (category == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Produkt ktory probujesz usunac nie istnieje!");
                Console.WriteLine("WRACAM DO MENU");
                Thread.Sleep(1000);
            }
            else
            {
                if (category.Name == "Produkt spozywczy")
                {
                    category.RemoveFoodProduct(productname);
                }
                else if (category.Name == "Produkt elektroniczny")
                {
                    category.RemoveElectroProduct(productname);
                }
                else if (category.Name == "Produkt markowy")
                {
                    category.RemoveBrandProduct(productname);
                }
                else
                {
                    category.RemoveProduct(productname);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Usunieto {productname} z kategorii {category.Name}");
            }
        }
        public void FindProduct()
        {
            Console.Write("Podaj nazwe produktu ktorego szukasz: ");
            string productname= Console.ReadLine();

            Category category = Assortment.SearchCategory(productname);
            if (category == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nie ma takiego produktu!");
                Console.WriteLine("WRACAM DO MENU");
                Thread.Sleep(1000);
            }
            else if (category.Name == "Produkt spozywczy") 
            {
                FoodProduct foodproduct = category.SearchFoodProduct(productname);
                Console.WriteLine($"Produkt {foodproduct.Name} znajduje sie w kategorii {category.Name} i kosztuje {foodproduct.Price} zl");
            }
            else if (category.Name == "Produkt elektroniczny")
            {
                ElectronicProduct electronicproduct = category.SearchElectronicProduct(productname);
                Console.WriteLine($"Produkt {electronicproduct.Name} znajduje sie w kategorii {category.Name} i kosztuje {electronicproduct.Price} zl");
            }
            else if (category.Name == "Produkt markowy")
            {
                BrandProduct brandproduct = category.SearchBrandProduct(productname);
                Console.WriteLine($"Produkt {brandproduct.Name} znajduje sie w kategorii {category.Name} i kosztuje {brandproduct.Price} zl");
            }
            else
            {
                Product product = category.SearchProduct(productname);
                Console.WriteLine($"Produkt {product.Name} znajduje sie w kategorii {category.Name} i kosztuje {product.Price} zl");
            }      
        }
        public void CreateOrder()
        {
            Console.Write("Podaj ID identyfikujace zamowienie: ");
            try
            {
                string choice;
                int ID = int.Parse(Console.ReadLine());
                Order order = Orders.Find(k => k.ID == ID);

                while (true)
                {
                    if (order != null)
                    {
                        Console.WriteLine("Podane ID jest juz zajete!");
                        Console.Write("Podaj ID identyfikujace zamowienie jeszcze raz: ");
                        ID = int.Parse(Console.ReadLine());
                        order = Orders.Find(k => k.ID == ID);
                    }

                    else
                        break;
                }

                order = new Order(ID);
        
                while (true)
                {
                    Console.Write("Podaj nazwe produktu ktory chcesz dodac do zamowienia: ");
                    string productname = Console.ReadLine();

                    Category category = Assortment.SearchCategory(productname);

                    if (category == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Nie ma takiego produktu!");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Chcesz kontyunowac dodawanie? [T/n]: ");
                        choice = Console.ReadLine();
                        if (choice == "n") break;
                        else if (choice != "T" && choice != "n")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Podales bledna wartosc!");
                            Console.WriteLine("WRACAM DO MENU");
                            Thread.Sleep(1000);
                            break;
                        }
                    }
                    else
                    {
                        if (category.Name == "Produkt spozywczy")
                        {
                            FoodProduct foodproduct = category.SearchFoodProduct(productname);
                            order.AddFoodProduct(foodproduct);
                        }
                        else if (category.Name == "Produkt elektroniczny")
                        {
                            ElectronicProduct electronicproduct = category.SearchElectronicProduct(productname);
                            order.AddElectroProduct(electronicproduct);
                        }
                        else if (category.Name == "Produkt markowy")
                        {
                            BrandProduct brandproduct = category.SearchBrandProduct(productname);
                            order.AddBrandProduct(brandproduct);
                        }
                        else
                        {
                            Product product = category.SearchProduct(productname);
                            order.AddProduct(product);
                        }
                        
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Pomyslnie dodano produkt");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Czy chcesz dodac jeszcze jeden produkt? [T/n]: ");
                        choice = Console.ReadLine();

                        if (choice == "n") break;
                        else if (choice != "T" && choice!="n")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Podales bledna wartosc!");
                            Console.WriteLine("WRACAM DO MENU");
                            Thread.Sleep(1000);
                            break;
                        }
                    }
                }
                if (order.TotalPrice != 0)
                {
                    Orders.Add(order);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Dodano zamowienie do listy zamowien");
                }
            }
            catch (Exception) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Podales bledna wartosc!");
                Console.WriteLine("WRACAM DO MENU");
                Thread.Sleep(1000);
            }
        }
        public void DisplayOrders()
        {
            if (Orders.Count > 0) 
            {
                Console.WriteLine("Zlozone zamowienia: \n");
                foreach (Order order in Orders)
                {
                    Console.WriteLine($"========= ZAMOWIENIE NR {order.ID} ==========");
                    foreach (Product product in order.Products)
                    {
                        Console.WriteLine($"[*] {product.Name}: {product.Price} zl");
                    }
                    foreach (ElectronicProduct product in order.ElectronicProducts)
                    {
                        Console.WriteLine($"[*] {product.Name}: {product.Price} zl");
                    }
                    foreach (FoodProduct product in order.FoodProducts)
                    {
                        Console.WriteLine($"[*] {product.Name}: {product.Price} zl");
                    }
                    foreach (BrandProduct product in order.BrandProducts)
                    {
                        Console.WriteLine($"[*] {product.Name}: {product.Price} zl");
                    }
                    Console.WriteLine("\nCena calego zamowienia: " + order.TotalPrice + " zł");
                    Console.WriteLine("====================================\n");
                }
            }
            else
            {   
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nie ma obecnie zadnych zamowien");
                Console.WriteLine("WRACAM DO MENU");
                Thread.Sleep(1000);
            }
        }
        public void DeleteOrder()
        {
            Console.Write("Podaj ID zamowienia ktore chcesz usunac: ");
            int ID = int.Parse(Console.ReadLine());
            Order order = Orders.Find(k => k.ID == ID);
            if (order == null) 
            {   
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Zamowienie z podanym ID nie istnieje");
                Console.WriteLine("WRACAM DO MENU");
                Thread.Sleep(1000);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nPomyslnie usnieto zamowienie o ID: {order.ID}\n");
                Orders.Remove(order);
            }
        }
        public void ModifyOrder()
        {
            string productname;
            int ID, choice;
            bool Loop = true;

            if (Orders.Count > 0)
            {
                Console.WriteLine("Wybierz opcje: ");
                Console.WriteLine("[1] Usun produkt z zamowienia");
                Console.WriteLine("[2] Dodaj produkt do zamowienia");
                try
                {
                    Console.Write("Opcja: ");
                    choice = int.Parse(Console.ReadLine());
                    if (choice == 1 || choice == 2)
                    {
                        Console.Write("Podaj ID identyfikujace zamowienie: ");
                        ID = int.Parse(Console.ReadLine());
                        Order order = Orders.Find(k => k.ID == ID);

                        if (order == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Podane ID Zamowienia nie istnieje!");
                            Console.WriteLine("WRACAM DO MENU");
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            while (Loop == true)
                            {

                                if (choice == 1)
                                {
                                    Console.WriteLine("Podaj nazwe produktu ktory chcesz usunac");
                                    Console.WriteLine($"========= Zamowienie nr {order.ID} ==========");
                                    foreach (FoodProduct product in order.FoodProducts)
                                    {
                                        Console.WriteLine($"[*] {product.Name}: {product.Price} zl");
                                    }
                                    foreach (ElectronicProduct product in order.ElectronicProducts)
                                    {
                                        Console.WriteLine($"[*] {product.Name}: {product.Price} zl");
                                    }
                                    foreach (BrandProduct product in order.BrandProducts)
                                    {
                                        Console.WriteLine($"[*] {product.Name}: {product.Price} zl");
                                    }
                                    foreach (Product product in order.Products)
                                    {
                                        Console.WriteLine($"[*] {product.Name}: {product.Price} zl");
                                    }

                                    Console.WriteLine("\nCena calego zamowienia: " + order.TotalPrice + " zł");
                                    Console.WriteLine("====================================\n");
                                    Console.Write("Nazwa produktu: ");

                                    productname = Console.ReadLine();

                                    if (order.SearchFoodProduct(productname) != null)
                                    {
                                        order.RemoveFoodProduct(productname);
                                        break;
                                    }
                                    else if (order.SearchElectronicProduct(productname) != null)
                                    {
                                        order.RemoveElectroProduct(productname);
                                        break;
                                    }
                                    else if (order.SearchBrandProduct(productname) != null)
                                    {
                                        order.RemoveBrandProduct(productname);
                                        break;
                                    }
                                    else if (order.SearchProduct(productname) != null)
                                    {
                                        order.RemoveProduct(productname);
                                        break;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Nie ma takiego produktu!");
                                        Console.WriteLine("WRACAM DO MENU");
                                        Thread.Sleep(1000);
                                        break;
                                    }
                                }
                                else if (choice == 2) //dodaje do zamowienia tylko opcje z zamowienia a nie z Asortymentu sklepu
                                {
                                    Console.Write($"Podaj nazwe produktu ktory chcesz dodac do Zamowienia nr {order.ID}: ");
                                    productname = Console.ReadLine();

                                    Category category = Assortment.SearchCategory(productname);

                                    if (category.SearchFoodProduct(productname) != null)
                                    {
                                        FoodProduct foodproduct = category.SearchFoodProduct(productname);
                                        order.AddFoodProduct(foodproduct);
                                        break;
                                    }
                                    else if (order.SearchElectronicProduct(productname) != null)
                                    {
                                        ElectronicProduct electronicproduct = category.SearchElectronicProduct(productname);
                                        order.AddElectroProduct(electronicproduct);
                                        break;
                                    }
                                    else if (order.SearchBrandProduct(productname) != null)
                                    {
                                        BrandProduct brandproduct = category.SearchBrandProduct(productname);
                                        order.AddBrandProduct(brandproduct);
                                        break;
                                    }
                                    else if (order.SearchProduct(productname) != null)
                                    {
                                        Product product = category.SearchProduct(productname);
                                        order.AddProduct(product);
                                        break;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Nie ma takiego produktu!");
                                        Console.WriteLine("WRACAM DO MENU");
                                        Thread.Sleep(1000);
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Podales bledna wartosc!");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                }
                            }
                            if (order.TotalPrice == 0)
                            {
                                Orders.Remove(order);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Usunales wszystkie Produkty z zamowienia, usuwam Zamowienie nr {order.ID}");
                            }
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Podana opcja nie istnieje");
                        Console.WriteLine("WRACAM DO MENU");
                        Thread.Sleep(1000);
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Podales bledna wartosc!");
                    Console.WriteLine("WRACAM DO MENU");
                    Thread.Sleep(1000);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nie ma obecnie zadnych zamowien!");
                Console.WriteLine("WRACAM DO MENU");
                Thread.Sleep(1000);
            }
        }
        public void CreateReceipt()
        {
            Console.WriteLine("Wystawiam rachunek");
            Console.Write("Podaj ID zamowienia do wystawienia rachunku: ");

            try
            {
                int ID = int.Parse(Console.ReadLine());

                Order order = Orders.Find(k => k.ID == ID);
                Receipt receipt = Receipts.Find(r => r.ReceiptID == ID);
                Invoice invoice = Invoices.Find(i => i.InvoiceID== ID);

                if (order == null || receipt != null || invoice != null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Zamowienie o podanym ID nie istnieje lub rachunek zostal juz wystawiony na dane zamowienie");
                    Console.WriteLine("WRACAM DO MENU");
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.Write("Wybierz opcje [Paragon/Faktura]: ");
                    string type = Console.ReadLine();
                    if (type == "Paragon")
                    {
                        Console.Write("Czy już zapłaciles za zamowienie? [Tak/nie]: ");
                        string choice = Console.ReadLine();

                        if (choice == "Tak" || choice == "tak")
                        {
                            Receipt bill = new Receipt(choice, ID);
                            Receipts.Add(bill);
                        }
                        else if (choice == "nie" || choice == "Nie")
                        {
                            Receipt bill = new Receipt(choice, ID);
                            Receipts.Add(bill);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Podano bledna wartosc");
                            Console.WriteLine("WRACAM DO MENU");
                            Thread.Sleep(1000);
                        }
                    }
                    else if (type == "Faktura")
                    {
                        Console.Write("Podaj nazwe firmy na ktora bierzesz fakture: ");
                        string CompanyName = Console.ReadLine();
                        Console.Write("Podaj numer NIP: ");
                        string NIP = Console.ReadLine();
                        Invoice bill = new Invoice(CompanyName, NIP, ID);
                        Invoices.Add(bill);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Podales bledna wartosc!");
                        Console.WriteLine("WRACAM DO MENU");
                        Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Podales bledna wartosc!");
                Console.WriteLine("WRACAM DO MENU");
                Thread.Sleep(1000);
            }

        }
        public void DisplayReceipts()
        {
            if (Receipts.Count <= 0 && Invoices.Count <= 0) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nie ma zadnych rachunkow!");
                Console.WriteLine("WRACAM DO MENU");
                Thread.Sleep(1000);
            }
            else
            {
                foreach (Order order in Orders)
                {
                    if (Receipts.Find(d => d.ReceiptID == order.ID) != null)
                    {
                        foreach(Receipt receipt in Receipts)
                        {
                            receipt.Print(order);
                            Console.WriteLine();
                        }
                    }
                    else if (Invoices.Find(d => d.InvoiceID== order.ID) != null)
                    {
                        foreach (Invoice invoice in Invoices)
                        {
                            invoice.Print(order);
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
        public void DeleteReceipt()
        {
            
            if (Invoices.Count > 0 || Receipts.Count > 0)
            {
                Console.Write("Podaj ID rachunku ktory chcesz usunac: ");
                try
                {
                    int ID = int.Parse(Console.ReadLine());

                    Invoice invoice = Invoices.Find(i => i.InvoiceID == ID);
                    Receipt receipt = Receipts.Find(r => r.ReceiptID == ID);

                    if (invoice == null && receipt == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Rachunek z podanym ID nie istnieje");
                        Console.WriteLine("WRACAM DO MENU");
                        Thread.Sleep(1000);
                    }
                    else if (invoice != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Invoices.Remove(invoice);
                        Console.WriteLine($"Pomyslnie usunieto Rachunek o ID: {invoice.InvoiceID}\n");
                    }
                    else if (receipt != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Receipts.Remove(receipt);
                        Console.WriteLine($"Pomyslnie usunieto Rachunek o ID: {receipt.ReceiptID}\n");
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Podano bledna wartosc");
                    Console.WriteLine("WRACAM DO MENU");
                    Thread.Sleep(1000);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nie ma zadnych rachunkow!");
                Console.WriteLine("WRACAM DO MENU");
                Thread.Sleep(1000);
            }
        }
    }
}
