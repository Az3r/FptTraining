using System;
using System.Collections.Generic;
using System.Linq;
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
    public PaginationDto<ProductMasterDto> FindProducts([FromQuery] FindProductRequest query)
    {
      var filter = requestService.ToProductFilter(query);
      var order = requestService.ToProductOrder(query);
      var products = database.ProductRepository.Find(filter, order, query.Size, query.Offset, out int total);

      var dtos = dtoService.ToProductMaster(products);
      var response = dtoService.ToPagination(dtos, total / query.Size, query.Size, query.Offset);

      return response;
    }

    [HttpGet("{id}")]
    public ActionResult<ProductDetailDto> GetProduct(Guid id)
    {
      var product = database.ProductRepository.GetProduct(id);
      if (product is null) return NotFound(id);

      var dto = dtoService.ToProductDetail(product);
      return Ok(dto);
    }

    [HttpPost]
    public IActionResult CreateProduct(CreateProductRequest body)
    {
      var product = requestService.ToProduct(body);

      // find and track Category entities,
      // so that Entity Framework won't try to insert new Category entities
      var categories = database.CategoryRepository.FindAndTrack(product.Categories.Select(c => c.ID));
      product.Categories = categories.ToList();
      database.ProductRepository.Create(product);
      database.Save();

      var dto = dtoService.ToProductDetail(product);
      return Created($"product/{product.ID}", dto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(Guid id, UpdateProductRequest body)
    {
      var product = requestService.ToProduct(id, body);
      database.ProductRepository.Update(product);
      database.Save();
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(Guid id)
    {
      database.ProductRepository.Delete(id);
      return NoContent();
    }

    private readonly IUnitOfWork database;
    private readonly IDtoService dtoService;
    private readonly IRequestService requestService;
  }
}
