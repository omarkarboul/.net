using PS.Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Services
{
    public interface IProductService : IService<Product>
    {
        //void Add(Product p);
        //void Remove(Product p);
        //IEnumerable<Product> GetAll();
        //void Commit();

        IEnumerable<Product> FindMost5ExpensiveProds();
        float UnavailableProductsPercentage();

        IEnumerable<Product> GetProdsByClient(Client c);

        void DeleteOldProducts();
    }
}
