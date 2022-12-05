using Microsoft.AspNetCore.Mvc;
using NurayMarhanPortalGroup.Business.Abstract;
using NurayMarhanPortalGroup.Business.Concrete;
using NurayMarhanPortalGroup.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurayMarhanPortalGroup.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController:ControllerBase
    {
        private readonly IGenericService<Customer> _customer;

        public CustomerController(IGenericService<Customer> customer)
        {
            _customer = customer;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddCustomer([FromBody]Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool result = await MernisValidations.ValidationTc(customer);
                    if (result)
                    {
                        var addCustomer = _customer.Add(customer);
                        return Ok(addCustomer);
                    }
                    else
                    {

                        return BadRequest();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }
            else
                return BadRequest();

        }

        [HttpGet]
        [Route("GetAllCustomers")]
        public IActionResult GetAllCustomers()
        {
            return Ok(_customer.GetAll());
        }

        [HttpGet]
        [Route("GetCustomer/{id}")]
        public IActionResult GetCustomer(int id)
        {
            try
            {
                var result = _customer.GetById(id);
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest();
            }           
            
        }

        

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customer customer)
        {
            try
            {
                bool result = await MernisValidations.ValidationTc(customer);
                if (result)
                {
                    var UpdateCustomer = _customer.Update(customer);
                    return Ok(UpdateCustomer);
                }
                else
                {

                    return BadRequest();
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [HttpDelete]
        [Route("DeleteCustomer/{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                _customer.Remove(_customer.GetById(id));
                return Ok("Müşteri Silindi!");
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
