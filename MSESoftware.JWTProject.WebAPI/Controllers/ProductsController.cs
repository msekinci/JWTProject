using Microsoft.AspNetCore.Mvc;
using MSESoftware.JWTProject.Business.Interfaces;
using MSESoftware.JWTProject.Entities.Concrete;
using MSESoftware.JWTProject.Entities.DTOs.ProductDTOs;
using MSESoftware.JWTProject.WebAPI.CustomFilters;
using System.Threading.Tasks;

namespace MSESoftware.JWTProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allProducts = await _productService.GetAllAsync();
            return Ok(allProducts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [ValidModel]
        [HttpPost]
        public async Task<IActionResult> Add(ProductAddDTO productAddDTO)
        {
            await _productService.AddAsync(new Product { Name = productAddDTO.Name });
            return Created("", productAddDTO);
        }

        [ValidModel]
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDTO productUpdateDTO)
        {
            await _productService.UpdateAsync(new Product { Id = productUpdateDTO.Id, Name = productUpdateDTO.Name });
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.RemoveAsync(new Product { Id = id });
            return NoContent();
        }
    }
}