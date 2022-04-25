using PS.Domain;
using PS.Services;
using PSData;
using System;
using System.Collections.Generic;

namespace PS.GUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Product p = new Product();
            p.Name = "rrere";
            Console.WriteLine(p.Name);

            //initialiseur d'objet :
            Product p2 = new Product
            {
                Name = "test",
                Price = 1.5,

            };
            Console.WriteLine(p2);

            Provider pro = new Provider
            {
                Password = "adsefef",
                ConfirmPassword="fafafa",
                UserName = "user1",
                Email ="user1@gmail.com"
            };

            Provider.SetIsApproved(pro.Password, pro.ConfirmPassword, pro.IsApproved);

            Console.WriteLine("login 1 : ");
            Console.WriteLine(pro.login("user1", "adsefef"));
            Console.WriteLine("login 2 : ");
            Console.WriteLine(pro.login("user1", "adsefef", "user1@gmail.cfrgom"));
            //forcer passage par reference
            //int i = 3;
            //int j = 2;
            //int k = 1;
            //p.calculer(i, j, ref k);
            //Console.WriteLine(k);

            //test getmytype

            Product pp = new Product();
            Product ch = new Chemical();
            Biological bio = new Biological();
            pp.GetMyName();
            ch.GetMyName();
            bio.GetMyName();

            //add products to provider
            pro.Products = new List<Product>();
            pro.Products.Add(p2);
            pro.Products.Add(p);
            pro.getDetails();

            Console.WriteLine("test get products :");
            pro.GetProducts("Name", "test");


            //tester la partie delegué
            ManageProduct maprod = new ManageProduct();
            maprod.products.Add(p);
            maprod.products.Add(p2);
            Console.WriteLine("tester delegué");
            foreach(Product prod in maprod.FindProduct('t'))
            {
                Console.WriteLine(prod);
            }

            // les methodes d'extension
            string s = "bonjour";
            Console.WriteLine(s.ToUpper());

            StrExtension.UpperCase(s);

            //insertion dans DB

            Chemical chem = new Chemical();
            chem.Name = "azea";
            Biological biolo = new Biological();
            biolo.Name = "azea";

            Category cat = new Category { Name = "legume" };
            p.Category = cat;

            PSContext ctx = new PSContext();
            ctx.Products.Add(p);
            //ctx.Chemicals.Add(chem);
            //ctx.Biologicals.Add(biolo);
            
            ctx.SaveChanges();

            Console.WriteLine("insert done ! ");

            foreach(Product prod in ctx.Products)
            {
                Console.WriteLine("product: "+prod.Name+ "Category: "+ prod.Category.Name);
            }

        }
    }
}
