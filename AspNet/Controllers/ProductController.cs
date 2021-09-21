using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProductServer.ApiModels;
using ProductServer.DTOs;
using ProductServer.Repositories;
using ProductServer.Services;

namespace ProductServer.Controllers
{
  [Route("api/product")]
  [ApiController]
  public class ProductController : ControllerBase
  {
    public ProductController(IUnitOfWork worker, IDtoService mapper, IRequestService transform)
    {
      this.worker = worker;
      this.mapper = mapper;
      this.transform = transform;
    }

    [HttpGet("all")]
    public List<ProductMasterDto> GetAllProducts()
    {
      var products = worker.ProductRepository.GetAll();
      var dtos = mapper.ToProductMaster(products);
      return dtos;
    }

    [HttpGet]
    public List<ProductMasterDto> FindProducts(string name,
                                          string category,
                                          double minPrice,
                                          double maxPrice,
                                          string order,
                                          int size = 20,
                                          int offset = 0)
    {
      return new List<ProductMasterDto>();
    }

    [HttpGet("{id}")]
    public ProductDetailDto GetProduct(Guid id)
    {
      var product = worker.ProductRepository.GetProduct(id);
      var dto = mapper.ToProductDetail(product);

      return dto;
    }

    [HttpPost]
    public IActionResult CreateProduct(CreateProductRequest body)
    {
      return Created(Guid.NewGuid().ToString(), body);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(UpdateProductRequest body)
    {
      return Ok(body);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(Guid id)
    {
      return Ok();
    }

    private readonly IUnitOfWork worker;
    private readonly IDtoService mapper;
    private readonly IRequestService transform;
  }
}
