using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PreorderSystemForCanteen.Models;

namespace PreorderSystemForCanteen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products;

        public ProductController()
        {
            products = new List<Product>()
            {
                new Product() {ProductId = 1, Name = "Red Borsh", Type = "Entree", Price = 300},
                new Product() {ProductId = 2, Name = "Chicken pilaf", Type = "Second dish", Price = 600},
                new Product() {ProductId = 3, Name = "Vegetable salad", Type = "Cold snack", Price = 200},
                new Product() {ProductId = 4, Name = "Omelet", Type = "Second dish", Price = 500},
                new Product() {ProductId = 5, Name = "Oatmel", Type = "Breakfaast", Price = 200},
                new Product() {ProductId = 6, Name = "Compote", Type = "Drink", Price = 90},
            };

        }

        [HttpGet]
        public List<Product> GetAllProducts()
        {
            return products;
        }

        [HttpGet("id/{productId}")]
        public List<Product> GetProductById(int productId)
        {
            return products.Where(p => p.ProductId == productId).ToList();
        }

        [HttpGet("{param}/{name}")]
        public List<Product> GetProductsWithFilter(string param, string value, int price)
        {
            
            if(param.ToLower().Equals("name"))
            {
                return products.Where(p => p.Name.ToLower() == value.ToLower()).ToList();
            }
            else if (param.ToLower().Equals("type"))
            {
                return products.Where(p => p.Type.ToLower() == value.ToLower()).ToList();
            }
            else if(param.Equals(price))
            {
                return products.Where(p => p.Price == price).ToList();
            }
            return null;
           
        }

        [HttpGet("add/{id}/{name}/{type}/{price}")]
        public List<Product> AddProduct(int id, string name, string type, int price)
        {
             products.Add(new Product
            {
                ProductId = id,
                Name = name,
                Type = type,
                Price = price
            });

            return products;
               

           
        }

      
        [HttpGet("remove/{id}")]
        public List<Product> RemoveProduct(int id)
        {
            products.RemoveAll(p => p.ProductId == id);
            return products;
        }

        public List<Product> UpdateProduct()
        {


            return null;
        }



    }
}
