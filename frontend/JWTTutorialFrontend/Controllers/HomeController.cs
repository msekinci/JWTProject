using System.Threading.Tasks;
using JWTTutorialFrontend.APIServices.Interfaces;
using JWTTutorialFrontend.CustomFilters;
using JWTTutorialFrontend.Models;
using Microsoft.AspNetCore.Mvc;

namespace JWTTutorialFrontend.Controllers
{
    public class HomeController : Controller
    {

        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        [JwtAuthorize(Roles = "Admin,Member")]
        public async Task<IActionResult> Index()
        {
            var productList = await _productService.GetAllAsync();
            return View(productList);
        }

        [JwtAuthorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [JwtAuthorize(Roles = "Admin")]
        public async Task<IActionResult> Create(ProductAdd product)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddAsync(product);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "An error occured while adding");
            return View(product);
        }

        [JwtAuthorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product != null)
            {
                return View(new ProductUpdate { Id = product.Id, Name = product.Name });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [JwtAuthorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(ProductUpdate productUpdate)
        {
            if (ModelState.IsValid)
            {
                await _productService.UpdateAsync(productUpdate);
                return RedirectToAction("Index");
            }
            return View(productUpdate);
        }

        [JwtAuthorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}