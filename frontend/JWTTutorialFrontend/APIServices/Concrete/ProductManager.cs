using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using JWTTutorialFrontend.APIServices.Interfaces;
using JWTTutorialFrontend.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace JWTTutorialFrontend.APIServices.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IHttpContextAccessor _httpContext;
        public ProductManager(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public async Task AddAsync(ProductAdd product)
        {
            var token = _httpContext.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                string jsonData = JsonConvert.SerializeObject(product);
                var stringContent = new StringContent
                (
                    jsonData, Encoding.UTF8, "application/json"
                );
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await httpClient.PostAsync("http://localhost:61681/api/Products/",stringContent);
            }
        }

        public async Task<List<ProductList>> GetAllAsync()
        {
            var token = _httpContext.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await httpClient.GetAsync("http://localhost:61681/api/Products/");
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<List<ProductList>>(await response.Content.ReadAsStringAsync());
                }
            }
            return null;
        }

        public async Task<ProductList> GetByIdAsync(int id)
        {
            var token = _httpContext.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await httpClient.GetAsync("http://localhost:61681/api/Products/" + id);
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<ProductList>(await response.Content.ReadAsStringAsync());
                }
            }
            return null;
        }

        public async Task UpdateAsync(ProductUpdate product)
        {
            var token = _httpContext.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                string jsonData = JsonConvert.SerializeObject(product);
                var stringContent = new StringContent
                (
                    jsonData, Encoding.UTF8, "application/json"
                );
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                await httpClient.PutAsync("http://localhost:61681/api/Products/", stringContent);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var token = _httpContext.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                await httpClient.DeleteAsync($"http://localhost:61681/api/Products/{id}");
            }
        }
    }
}