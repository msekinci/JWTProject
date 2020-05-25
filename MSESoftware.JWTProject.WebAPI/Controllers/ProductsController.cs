using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MSESoftware.JWTProject.Business.Interfaces;
using MSESoftware.JWTProject.Entities.Concrete;
using MSESoftware.JWTProject.Entities.DTOs.ProductDTOs;
using MSESoftware.JWTProject.WebAPI.CustomFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSESoftware.JWTProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allProducts = await _productService.GetAllAsync();
            return Ok(_mapper.Map<List<ProductListDTO>>(allProducts));
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(_mapper.Map<ProductListDTO>(product));
        }

        [ValidModel]
        [HttpPost]
        public async Task<IActionResult> Add(ProductAddDTO productAddDTO)
        {
            await _productService.AddAsync(_mapper.Map<Product>(productAddDTO));
            return Created("", productAddDTO);
        }

        [ValidModel]
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDTO productUpdateDTO)
        {
            await _productService.UpdateAsync(_mapper.Map<Product>(productUpdateDTO));
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.RemoveAsync(new Product { Id = id });
            return NoContent();
        }
    }
}