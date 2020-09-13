using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PreorderSystemForCanteen.Models;
using PreorderSystemForCanteen.Repositories.Interfaces;

namespace PreorderSystemForCanteen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(productRepository.GetAllProducts());
        }

        [HttpGet("id/{productId}")]
        public IActionResult GetProductById(int productId)
        {
            return Ok(productRepository.GetProductById(productId));
        }

        [HttpGet("name/{name}")]
        public IActionResult GetProductByName(string name)
        {
            var product = Ok(productRepository.GetProductByName(name));
            if (product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("{param}/{name}")]
        public IActionResult GetProductsWithFilter(string param, string value, int price)
        {
            return Ok(productRepository.GetProductsWithFilter(param, value, price));
        }

        [HttpGet("add/{id}/{name}/{type}/{price}")]
        public IActionResult AddProduct(int id, string name, string type, int price)
        {
            return Ok(productRepository.AddProduct(id, name, type, price));
        }


        [HttpGet("remove/{id}")]
        public IActionResult RemoveProduct(int id)
        {
            return Ok(productRepository.RemoveProduct(id));
        }

        public IActionResult UpdateProduct()
        {
            return null;
        }



    }
}
