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
    public class CustomerController : Controller
    {
        HttpClient _client = new HttpClient() { BaseAddress = new Uri("https://localhost:44306/") };
        public IActionResult Index()          
        {
            return View();
        }

   
        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer customer) 
        {
            customer.CreationDate = DateTime.Now;
            customer.Status = true;
            var response = await _client.PostAsJsonAsync("api/Customer/AddCustomer",customer); 
            if (response.IsSuccessStatusCode) 
            {
                TempData["Message"] = "Başarıyla Kayıt Yapıldı";
                return RedirectToAction("Index");
                
            }
            else 
            { 
                TempData["Message"] = "Kimlik Bilgileri Doğru Değildir"; 
                return RedirectToAction("Index"); 
            } 
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCustomer(int id)
        {
            
            var response = await _client.GetAsync($"api/Customer/GetCustomer/{id}");
            Customer customer = response.Content.ReadFromJsonAsync<Customer>().Result;
            if (response.IsSuccessStatusCode)
            {
                
                return View(customer);

            }
            else
            {
                TempData["Message"] = "Kullanıcı Bulunamadı";
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
           
         
            var response = await _client.PutAsJsonAsync("api/Customer/UpdateCustomer", customer);
            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Başarıyla Güncellendi";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["Message"] = "Güncelleme Yapılamadı";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCustomer(int id)
        {

            var response = await _client.GetAsync($"api/Customer/GetCustomer/{id}");
            Customer customer = response.Content.ReadFromJsonAsync<Customer>().Result;
            if (response.IsSuccessStatusCode)
            {

                return View(customer);

            }
            else
            {
                TempData["Message"] = "Kullanıcı Bulunamadı";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCustomer(Customer customer)
        {

            var response = await _client.DeleteAsync($"api/Customer/DeleteCustomer/{customer.ID}");
            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Müşteri Silindi!";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["Message"] = "Silme İşlemi Gerçekleştirilemedi!";
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> GetAllCustomers()
        {
            var responseCustomer = await _client.GetAsync("api/Customer/GetAllCustomers");
            ViewBag.Customers = responseCustomer.Content.ReadFromJsonAsync<List<Customer>>().Result;
            return View(ViewBag.Customers);
        }

    }
}
