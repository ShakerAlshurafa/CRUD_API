using Crud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "product1", Description = "This is product1"},
            new Product { Id = 2, Name = "product2", Description = "This is product2"},
            new Product { Id = 3, Name = "product3", Description = "This is product3"},
        };

        [HttpGet("Get")]
        public IActionResult Get()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Add(Product request)
        {
            if(request == null)
            {
                return NotFound();
            }
            products.Add(request);
            return Ok(products);
        }

        [HttpPut]
        public IActionResult Update(int id, Product request)
        {
            var currentProduct = products.FirstOrDefault(x => x.Id == id);
            if(currentProduct == null)
            {
                return NotFound();
            }
            currentProduct.Id = id;
            currentProduct.Name = request.Name;
            currentProduct.Description = request.Description;
            return Ok(currentProduct);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            products.Remove(product);
            return Ok();
        }
    }
}
