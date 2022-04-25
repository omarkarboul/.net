using PS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Services
{
    public class ManageProduct
    {
        public List<Product> products { get; set; } = new List<Product>();
        public Func<char, List<Product>> FindProduct;
        public Action<Category> ScanProduct;

        public List<Product> Method1(char c)
        {
            var req = from p in products
                      where p.Name.StartsWith(c)
                      select p;

            return req.ToList();
        }

        public List<Product> Method2(char c)
        {
            var req = from p in products
                      where p.Name.EndsWith(c)
                      select p;

            return req.ToList();
        }
        public ManageProduct()
        {
            FindProduct = Method1;
            FindProduct = Method2;
            FindProduct = c =>
            {
                var req = from p in products
                                     where p.Name.StartsWith(c)
                                     select p;

                return req.ToList();
            };
            ScanProduct = cat =>
            {
                var req = from p in products
                          where p.Category.CategoryId == cat.CategoryId
                          select p;
                foreach (Product pro in req)
                {
                    Console.WriteLine(pro);
                }
            };
        }

        public IEnumerable<Chemical> Get5Chemical(double price)
        {
            var req1 = from p in products.OfType<Chemical>()
                       where p.Price > price
                       select p;

            var req2 = products.Where(p => p.Price > price).OfType<Chemical>();
            return req2.Take(5);
        }

        //ignorer les 2 premiers produit return req2.skip(2);

        public double GetAveragePrice()
        {
            return products.Average(p => p.Price);
        }

        public double GetMaxPrice()
        {
            return products.Max(p => p.Price);
        }

        public Product GetProductMaxPrice()
        {
            var maxPrice = products.Max(p => p.Price);
            return products.Where(p => p.Price == maxPrice).First();
        }

        public int GetCountProducts(string city)
        {
            var req1 = from p in products.OfType<Chemical>()
                       where p.Adress.City == city
                       select p;

            return req1.Count();
        }


        public int GetCountProducts2(string city)
        {
            return products.OfType<Chemical>().Where(p => p.Adress.City == city).Count();
        }

        public IEnumerable<Chemical> GetChemicalByCity()
        {
            var req1 = from p in products.OfType<Chemical>()
                       orderby p.Adress.City descending
                       select p;
            return req1;
        }

        public IEnumerable<Chemical> GetChemicalByCity2()
        {
            return products.OfType<Chemical>().OrderBy(p => p.Adress.City);
        }

        public IEnumerable<IGrouping<string, Chemical>> GetChemicalGroupByCity()
        {
            var req1 = from p in products.OfType<Chemical>()
                       orderby p.Adress.City
                       group p by p.Adress.City;
                       
            foreach(var g in req1)
            {
                Console.WriteLine(g.Key);
                foreach(var v in g)
                {
                    Console.WriteLine(v);
                }
            }
            return req1;

            
        }

        public IEnumerable<IGrouping<string, Chemical>> GetChemicalGroupByCity2()
        {
            return products.OfType<Chemical>().OrderByDescending(p => p.Adress.City).GroupBy(p => p.Adress.City);


        }
    }
}
