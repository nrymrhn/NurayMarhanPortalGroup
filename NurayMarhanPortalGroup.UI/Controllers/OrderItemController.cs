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
    public class OrderItemController : Controller
    {
        HttpClient _client = new HttpClient() { BaseAddress= new Uri("https://localhost:44306/") };
        public async Task<IActionResult> Index()
        {
          
            var responseProduct = await _client.GetAsync("api/Product/GetAllProducts");
            var responseOrder = await _client.GetAsync("api/Order/GetAllOrders");
            ViewBag.Products = responseProduct.Content.ReadFromJsonAsync<List<Product>>().Result;
            ViewBag.Orders = responseOrder.Content.ReadFromJsonAsync<List<Order>>().Result;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddOrderItem(OrderItem orderItem)
        {
            orderItem.CreationDate = DateTime.Now;
            orderItem.Status = true;
            var response = await _client.PostAsJsonAsync("api/OrderItem/AddOrderItem", orderItem);

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
        public async Task<IActionResult> UpdateOrderItem(int id)
        {
            var responseProduct = await _client.GetAsync("api/Product/GetAllProducts");
            var responseOrder = await _client.GetAsync("api/Order/GetAllOrders");
            ViewBag.Orders = responseOrder.Content.ReadFromJsonAsync<List<Order>>().Result;
            ViewBag.Products = responseProduct.Content.ReadFromJsonAsync<List<Product>>().Result;

            var response = await _client.GetAsync($"api/OrderItem/GetOrderItem/{id}");
            OrderItem orderItem = response.Content.ReadFromJsonAsync<OrderItem>().Result;
            if (response.IsSuccessStatusCode)
            {

                return View(orderItem);

            }
            else
            {
                TempData["Message"] = "Sipariş Bulunamadı";
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrderItem(OrderItem orderItem)
        {


            var response = await _client.PutAsJsonAsync("api/OrderItem/UpdateOrderItem", orderItem);
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
        public async Task<IActionResult> DeleteOrderItem(int id)
        {

            var response = await _client.GetAsync($"api/OrderItem/GetOrderItem/{id}");
            OrderItem orderItem = response.Content.ReadFromJsonAsync<OrderItem>().Result;
            if (response.IsSuccessStatusCode)
            {

                return View(orderItem);

            }
            else
            {
                TempData["Message"] = "Sipariş Bulunamadı";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrderItem(OrderItem orderItem)
        {

            var response = await _client.DeleteAsync($"api/OrderItem/DeleteOrderItem/{orderItem.ID}");
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

        public async Task<IActionResult> GetAllOrderItems()
        {
            var responseOrderItem = await _client.GetAsync("api/OrderItem/GetAllOrderItems");
            ViewBag.OrderItems = responseOrderItem.Content.ReadFromJsonAsync<List<OrderItem>>().Result;
            return View(ViewBag.OrderItems);
        }
    }
}
