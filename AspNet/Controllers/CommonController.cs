using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductServer.DTOs;
using ProductServer.Repositories;
using ProductServer.Services;

namespace ProductServer.Controllers
{
  [ApiController]
  [Route("api")]
  public class CommonCOntroller : ControllerBase
  {

    public CommonCOntroller(IUnitOfWork database, IDtoService dtoService)
    {
      this.database = database;
      this.dtoService = dtoService;
    }

    [HttpGet("category/all")]
    public List<CategoryDto> GetAllCategories()
    {
      var categories = database.CategoryRepository.Entities.AsEnumerable();
      var dtos = dtoService.ToCategory(categories);
      return dtos;
    }

    [HttpGet("supplier/all")]
    public List<SupplierDto> GetAllSuppliers()
    {
      var suppliers = database.SupplierRepository.Entities.AsEnumerable();
      var dtos = dtoService.ToSupplier(suppliers);
      return dtos;
    }

    private IUnitOfWork database;
    private IDtoService dtoService;
  }
}