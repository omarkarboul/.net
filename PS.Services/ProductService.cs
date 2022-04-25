using PS.Domain;
using PSData;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public void DeleteOldProducts()
        {
            throw new NotImplementedException();
        }

        //PSContext ctx = new PSContext();

        //public void Add(Product p)
        //{
        //    ctx.Products.Add(p);
        //}

        //public void Commit()
        //{
        //    ctx.SaveChanges();
        //}

        //public IEnumerable<Product> GetAll()
        //{
        //    return ctx.Products;
        //}

        //public void Remove(Product p)
        //{
        //    ctx.Products.Remove(p);

        //}
        public IEnumerable<Product> FindMost5ExpensiveProds()
        {
            return GetMany().OrderByDescending(p => p.Price).Take(5);
        }

        public IEnumerable<Product> GetProdsByClient(Client c)
        {
            AchatService sa = new AchatService();
            return sa.GetMany(a => a.ClientFK == c.Cin).Select(f => f.Product);

        }

        
       
    

        public float UnavailableProductsPercentage()
        {
            int x = GetMany(p => p.Quantity == 0).Count();
            int y = GetMany().Count();
            return (float)(x / y)*100;
        }
    }
}

