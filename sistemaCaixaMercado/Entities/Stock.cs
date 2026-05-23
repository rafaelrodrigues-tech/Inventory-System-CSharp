using System;
using System.Collections.Generic;
using sistemaCaixaMercado.Entities.Exceptions;

namespace sistemaCaixaMercado.Entities
{
    class Stock
    {
        public List<Product> stock { get; set; } = new List<Product>();

        public Product Busca(int id)
        {
            return stock.Find(x => x.Id == id);
            
        }
        public void AddProduct(Product product)
        {
            stock.Add(product);
        }
        public void RemoveProduct(int id)
        { 
            var ProductRemove = stock.Find(x => x.Id == id);
            if (ProductRemove == null)
            {
                Console.WriteLine("Esse item não existe!");
            }
            else
            {
                stock.Remove(ProductRemove);
                Console.WriteLine("Produto Removido");
            }
        }
    }
}
