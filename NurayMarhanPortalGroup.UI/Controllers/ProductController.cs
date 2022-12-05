using Microsoft.AspNetCore.Mvc;
using NurayMarhanPortalGroup.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NurayMarhanPortalGroup.UI.Controllers
{
   
    public class ProductController : Controller
    {
        HttpClient _client = new HttpClient() { BaseAddress = new Uri("https://localhost:44306/") };
        public async Task<IActionResult> Index()
        {
            var responseCategory = await _client.GetAsync("api/Category/GetAllCategories");
            ViewBag.Categories = responseCategory.Content.ReadFromJsonAsync<List<Category>>().Result;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            product.CreationDate = DateTime.Now;
            product.Status = true;
            var response = await _client.PostAsJsonAsync("api/Product/AddProduct", product);
            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Başarıyla Ürün Eklendi";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["Message"] = "Ürün Eklenemedi";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var responseCategory = await _client.GetAsync("api/Category/GetAllCategories");
            ViewBag.Categories = responseCategory.Content.ReadFromJsonAsync<List<Category>>().Result;
            var response = await _client.GetAsync($"api/Product/GetProduct/{id}");
           Product product = response.Content.ReadFromJsonAsync<Product>().Result;
            if (response.IsSuccessStatusCode)
            {

                return View(product);

            }
            else
            {
                TempData["Message"] = "Ürün Bulunamadı";
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Product product)
        {


            var response = await _client.PutAsJsonAsync("api/Product/UpdateProduct", product);
            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Ürün Başarıyla Güncellendi";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["Message"] = "Güncelleme Yapılamadı";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int id)
        {

            var response = await _client.GetAsync($"api/Product/GetProduct/{id}");
            Product product = response.Content.ReadFromJsonAsync<Product>().Result;
            if (response.IsSuccessStatusCode)
            {

                return View(product);

            }
            else
            {
                TempData["Message"] = "Ürün Bulunamadı";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(Product product)
        {

            var response = await _client.DeleteAsync($"api/Product/DeleteProduct/{product.ID}");
            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Ürün Silindi!";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["Message"] = "Silme İşlemi Gerçekleştirilemedi!";
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> GetAllProducts()
        {
            var responseProduct = await _client.GetAsync("api/Product/GetAllProducts");
            ViewBag.Products = responseProduct.Content.ReadFromJsonAsync<List<Product>>().Result;
            return View(ViewBag.Products);
        }
    }
}
