using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.Api.Domain;

namespace papaMiaBackend.Api.Controller
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> _products = new();
        private static int _nextId = 1;

        [HttpGet]
        public ActionResult Index()
        {
            return Ok(_products);
        }

        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound(new { Message = "Product not found" });
            }
            return Ok(product);
        }

        [HttpPost]
        public ActionResult Create([FromBody] Product productData)
        {
            productData.Id = _nextId++;
            _products.Add(productData);
            return Ok(productData);
        }

        [HttpPut("{id}")]
        public ActionResult Edit([FromBody] Product productData, int id)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound(new { Message = "Product not found" });
            }

            existingProduct.Name = productData.Name;
            existingProduct.Price = productData.Price;
            existingProduct.Description = productData.Description;

            return Ok(existingProduct);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound(new { Message = "Product not found" });
            }

            _products.Remove(existingProduct);
            return NoContent();
        }
    }
}
