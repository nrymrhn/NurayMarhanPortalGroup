using Microsoft.AspNetCore.Mvc;
using NurayMarhanPortalGroup.Business.Abstract;
using NurayMarhanPortalGroup.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurayMarhanPortalGroup.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IGenericService<Order> _order;

        public OrderController(IGenericService<Order> order)
        {
            _order = order;
        }

        [HttpGet]
        [Route("GetAllOrders")]
        public IActionResult GetAllOrders()
        {
            return Ok(_order.GetAll());
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult AddOrder([FromBody] Order order)
        {


            try
            {
                var addOrder = _order.Add(order);
                return Ok(addOrder);

            }
            catch
            {

                return BadRequest();
            }



        }


        [HttpGet]
        [Route("GetOrder/{id}")]
        public IActionResult GetOrder(int id)
        {
            try
            {
                var result = _order.GetById(id);
                return Ok(result);
            }
            catch
            {

                return BadRequest();
            }

        }



        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateOrder([FromBody] Order order)
        {
            try
            {

                var updateOrder = _order.Update(order);
                return Ok(updateOrder);

            }
            catch
            {

                return BadRequest();
            }

        }

        [HttpDelete]
        [Route("DeleteOrder/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            try
            {
                _order.Remove(_order.GetById(id));
                return Ok("Silme Gerçekleştirildi!");
            }
            catch
            {

                return BadRequest();
            }
        }
    }
}
