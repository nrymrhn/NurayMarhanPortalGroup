using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NurayMarhanPortalGroup.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NurayMarhanPortalGroup.UI.Controllers
{
    public class AddressController : Controller
    {
        HttpClient _client = new HttpClient() { BaseAddress = new Uri("https://localhost:44306/") };
        public async Task<IActionResult> Index()
        {
            var responseCustomer = await _client.GetAsync("api/Customer/GetAllCustomers");
            ViewBag.Customers = responseCustomer.Content.ReadFromJsonAsync<List<Customer>>().Result;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAddress(Address address)
        {
            address.CreationDate = DateTime.Now;
            address.Status = true;
            var response = await _client.PostAsJsonAsync("api/Address/AddAddress", address);
            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Adres Eklendi";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["Message"] = "Adres Eklenemedi";
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        public async Task<IActionResult> UpdateAddress(int id)
        {
            var responseCustomer = await _client.GetAsync("api/Customer/GetAllCustomers");
            ViewBag.Customers = responseCustomer.Content.ReadFromJsonAsync<List<Customer>>().Result;
            var response = await _client.GetAsync($"api/Address/GetAddress/{id}");
            Address address = response.Content.ReadFromJsonAsync<Address>().Result;
            if (response.IsSuccessStatusCode)
            {

                return View(address);

            }
            else
            {
                TempData["Message"] = "Adres Bulunamadı";
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAddress(Address address)
        {


            var response = await _client.PutAsJsonAsync("api/Address/UpdateAddress", address);
            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Adres Başarıyla Güncellendi";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["Message"] = "Güncelleme Yapılamadı";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAddress(int id)
        {

            var response = await _client.GetAsync($"api/Address/GetAddress/{id}");
            Address address = response.Content.ReadFromJsonAsync<Address>().Result;
            if (response.IsSuccessStatusCode)
            {

                return View(address);

            }
            else
            {
                TempData["Message"] = "Adres Bulunamadı";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAddress(Address address)
        {

            var response = await _client.DeleteAsync($"api/Address/DeleteAddress/{address.ID}");
            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Adres Silindi!";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["Message"] = "Silme İşlemi Gerçekleştirilemedi!";
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> GetAllAddress()
        {
            var responseAddress = await _client.GetAsync("api/Address/GetAllAddress");
            ViewBag.Customers = responseAddress.Content.ReadFromJsonAsync<List<Address>>().Result;
            return View(ViewBag.Customers);
        }
    }
}
