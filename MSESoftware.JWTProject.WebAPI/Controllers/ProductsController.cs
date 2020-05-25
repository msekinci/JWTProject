using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MSESoftware.JWTProject.Business.Interfaces;
using MSESoftware.JWTProject.Business.StringInfos;
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

        [Authorize(Roles = RoleInfo.Admin + "," + RoleInfo.Member)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allProducts = await _productService.GetAllAsync();
            return Ok(_mapper.Map<List<ProductListDTO>>(allProducts));
        }

        [Authorize(Roles = RoleInfo.Admin + "," + RoleInfo.Member)]
        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(_mapper.Map<ProductListDTO>(product));
        }

        [Authorize(Roles = RoleInfo.Admin)]
        [ValidModel]
        [HttpPost]
        public async Task<IActionResult> Add(ProductAddDTO productAddDTO)
        {
            await _productService.AddAsync(_mapper.Map<Product>(productAddDTO));
            return Created("", productAddDTO);
        }

        [Authorize(Roles = RoleInfo.Admin)]
        [ValidModel]
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDTO productUpdateDTO)
        {
            await _productService.UpdateAsync(_mapper.Map<Product>(productUpdateDTO));
            return NoContent();
        }

        [Authorize(Roles = RoleInfo.Admin)]
        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.RemoveAsync(new Product { Id = id });
            return NoContent();
        }
    }
}