using PreorderSystemForCanteen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreorderSystemForCanteen.Repositories.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        List<Product> GetProductById(int id);
        List<Product> GetProductsWithFilter(string param, string value, int price);
        List<Product> AddProduct(int id, string name, string type, int price);
        List<Product> RemoveProduct(int id);
        List<Product> UpdateProduct();

        Product GetProductByName(string name);
    }
}
