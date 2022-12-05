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
    public class OrderItemController : ControllerBase
    {
        private readonly IGenericService<OrderItem> _orderItem;

        public OrderItemController(IGenericService<OrderItem> orderItem)
        {
            _orderItem = orderItem;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult AddOrderItem([FromBody] OrderItem orderItem)
        {

            try
            {
                var addOrderItem = _orderItem.Add(orderItem);
                return Ok(addOrderItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("GetAllOrderItems")]
        public IActionResult GetAllOrderItems()
        {
            return Ok(_orderItem.GetAll());
        }

        [HttpGet]
        [Route("GetOrderItem/{id}")]
        public IActionResult GetOrderItem(int id)
        {
            try
            {
                var result = _orderItem.GetById(id);
                return Ok(result);
            }
            catch
            {

                return BadRequest();
            }

        }



        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateOrderItem([FromBody] OrderItem orderItem)
        {
            try
            {

                var updateOrderItem = _orderItem.Update(orderItem);
                return Ok(updateOrderItem);

            }
            catch
            {

                return BadRequest();
            }

        }

        [HttpDelete]
        [Route("DeleteOrderItem/{id}")]
        public IActionResult DeleteOrderItem(int id)
        {
            try
            {
                _orderItem.Remove(_orderItem.GetById(id));
                return Ok("Sipariş Silindi!");
            }
            catch
            {

                return BadRequest();
            }
        }

    }
}
