using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductServer.ApiModels;
using ProductServer.Models;

namespace ProductServer.Controllers
{
  [Route("api/product")]
  [ApiController]
  [Authorize]
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

    [HttpGet("find")]
    public List<MockProduct> FindProducts(string name,
                                          string category,
                                          double minPrice,
                                          double maxPrice,
                                          int size = 20,
                                          int offset = 0)
    {
      return new List<MockProduct>();
    }

    [HttpPost("create")]
    public IActionResult CreateProduct(CreateProductRequest body)
    {
      return Created(Guid.NewGuid().ToString(), body);
    }

    [HttpPut("update")]
    public IActionResult UpdateProduct(UpdateProductRequest body)
    {
      return Ok(body);
    }

    [HttpDelete("delete/{id}")]
    public IActionResult DeleteProduct(Guid id)
    {
      return Ok();
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
