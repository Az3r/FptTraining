using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductServer.Models;

namespace ProductServer.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController(ProductContext products)
        {
            ProductContext = products;
        }

        [HttpGet("all")]
        public List<MockProduct> GetAllProducts()
        {
            using (StreamReader reader = new StreamReader("Mocks/products.json"))
            {
                string json = reader.ReadToEnd();
                List<MockProduct> products = JsonConvert.DeserializeObject<List<MockProduct>>(json);
                return products;
            }
        }





        private readonly ProductContext ProductContext;
    }

    public class MockProduct
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Rating { get; set; }
        public string Category { get; set; }
    }
}
