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
    public class CategoryController : Controller
    {
        HttpClient _client = new HttpClient() { BaseAddress= new Uri("https://localhost:44306/") };
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {
            category.CreationDate = DateTime.Now;
            category.Status = true;
            var response = await _client.PostAsJsonAsync("api/Category/AddCategory", category);
            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Kategori Eklendi";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["Message"] = "Kategori Eklenemedi";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {

            var response = await _client.GetAsync($"api/Category/GetCategory/{id}");
            Category category = response.Content.ReadFromJsonAsync<Category>().Result;
            if (response.IsSuccessStatusCode)
            {

                return View(category);

            }
            else
            {
                TempData["Message"] = "Kategori Bulunamadı";
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(Category category)
        {


            var response = await _client.PutAsJsonAsync("api/Category/UpdateCategory", category);
            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Kategori Başarıyla Güncellendi";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["Message"] = "Güncelleme Yapılamadı";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int id)
        {

            var response = await _client.GetAsync($"api/Category/GetCategory/{id}");
            Category category = response.Content.ReadFromJsonAsync<Category>().Result;
            if (response.IsSuccessStatusCode)
            {

                return View(category);

            }
            else
            {
                TempData["Message"] = "Kategori Bulunamadı";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(Category category)
        {

            var response = await _client.DeleteAsync($"api/Category/DeleteCategory/{category.ID}");
            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Kategori Silindi!";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["Message"] = "Silme İşlemi Gerçekleştirilemedi!";
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> GetAllCategories()
        {
            var responseCategories = await _client.GetAsync("api/Category/GetAllCategories");
            ViewBag.Categories = responseCategories.Content.ReadFromJsonAsync<List<Category>>().Result;
            return View(ViewBag.Categories);
        }
    }
}
