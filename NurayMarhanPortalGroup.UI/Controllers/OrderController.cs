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
    public class OrderController : Controller
    {
        HttpClient _client = new HttpClient() { BaseAddress = new Uri("https://localhost:44306/") };

        public async Task<IActionResult> Index()
        {
            var responseCustomer = await _client.GetAsync("api/Customer/GetAllCustomers");
            var responseAddress = await _client.GetAsync("api/Address/GetAllAddress");
                        
            ViewBag.Customers = responseCustomer.Content.ReadFromJsonAsync<List<Customer>>().Result;
            ViewBag.Addresses = responseAddress.Content.ReadFromJsonAsync<List<Address>>().Result;
            
              return View();
        }

      
        [HttpPost]
        public async Task<IActionResult> AddOrder(Order order)
        {
            order.CreationDate = DateTime.Now;
            order.Status = true;
            var response = await _client.PostAsJsonAsync("api/Order/AddOrder", order);
            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Sipariş Eklendi";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["Message"] = "Sipariş Eklenemedi";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateOrder(int id)
        {
            var responseCustomer = await _client.GetAsync("api/Customer/GetAllCustomers");
            var responseAddress = await _client.GetAsync("api/Address/GetAllAddress");
            ViewBag.Customers = responseCustomer.Content.ReadFromJsonAsync<List<Customer>>().Result;
            ViewBag.Addresses = responseAddress.Content.ReadFromJsonAsync<List<Address>>().Result;
            var response = await _client.GetAsync($"api/Order/GetOrder/{id}");
            Order order = response.Content.ReadFromJsonAsync<Order>().Result;
            if (response.IsSuccessStatusCode)
            {

                return View(order);

            }
            else
            {
                TempData["Message"] = "Sipariş Bulunamadı";
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrder(Order order)
        {


            var response = await _client.PutAsJsonAsync("api/Order/UpdateOrder", order);
            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Sipariş Başarıyla Güncellendi";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["Message"] = "Güncelleme Yapılamadı";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteOrder(int id)
        {

            var response = await _client.GetAsync($"api/Order/GetOrder/{id}");
            Order order = response.Content.ReadFromJsonAsync<Order>().Result;
            if (response.IsSuccessStatusCode)
            {

                return View(order);

            }
            else
            {
                TempData["Message"] = "Sipariş Bulunamadı";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrder(Order order)
        {

            var response = await _client.DeleteAsync($"api/Order/DeleteOrder/{order.ID}");
            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Sipariş Silindi!";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["Message"] = "Silme İşlemi Gerçekleştirilemedi!";
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> GetAllOrders()
        {
            var responseOrder = await _client.GetAsync("api/Order/GetAllOrders");
            ViewBag.Orders = responseOrder.Content.ReadFromJsonAsync<List<Order>>().Result;
            return View(ViewBag.Orders);
        }
    }
}
