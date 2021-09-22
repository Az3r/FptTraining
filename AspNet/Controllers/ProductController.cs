using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductServer.ApiModels;
using ProductServer.DTOs;
using ProductServer.Repositories;
using ProductServer.Services;

namespace ProductServer.Controllers
{
  [Route("api/product")]
  [ApiController]
  [Authorize]
  public class ProductController : ControllerBase
  {
    public ProductController(IUnitOfWork worker, IDtoService mapper, IRequestService transform)
    {
      this.database = worker;
      this.dtoService = mapper;
      this.requestService = transform;
    }

    [HttpGet("all")]
    public List<ProductMasterDto> GetAllProducts()
    {
      var products = database.ProductRepository.GetAll();
      var dtos = dtoService.ToProductMaster(products);
      return dtos;
    }

    [HttpGet]
    public List<ProductMasterDto> FindProducts([FromQuery] FindProductRequest query)
    {
      var filter = requestService.ToProductFilter(query);
      var sort = requestService.ToProductOrder(query);
      var products = database.ProductRepository.Find(filter, sort, query.Size, query.Offset);
      var dtos = dtoService.ToProductMaster(products);
      return dtos;
    }

    [HttpGet("{id}")]
    public ProductDetailDto GetProduct(Guid id)
    {
      var product = database.ProductRepository.GetProduct(id);
      var dto = dtoService.ToProductDetail(product);

      return dto;
    }

    [HttpPost]
    public IActionResult CreateProduct(CreateProductRequest body)
    {
      var product = requestService.ToProduct(body);
      database.ProductRepository.Create(product);
      var dto = dtoService.ToProductDetail(product);
      return Created($"product/{product.ID}", dto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(Guid id, UpdateProductRequest body)
    {
      var product = requestService.ToProduct(id, body);
      database.ProductRepository.Update(product);
      var dto = dtoService.ToProductDetail(product);
      return Ok(dto);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(Guid id)
    {
      database.ProductRepository.Delete(id);
      return Ok();
    }

    private readonly IUnitOfWork database;
    private readonly IDtoService dtoService;
    private readonly IRequestService requestService;
  }
}
