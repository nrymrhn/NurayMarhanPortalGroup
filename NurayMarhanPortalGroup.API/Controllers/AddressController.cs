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
    public class AddressController : ControllerBase
    {
        private readonly IGenericService<Address> _address;

        public AddressController(IGenericService<Address> address)
        {
            _address = address;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult AddAddress([FromBody] Address address)
        {


            try
            {
                var addAddress = _address.Add(address);
                return Ok(addAddress);

            }
            catch
            {

                return BadRequest();
            }

        }

        [HttpGet]
        [Route("GetAllAddress")]
        public IActionResult GetAllAddress()
        {
            return Ok(_address.GetAll());
        }

        [HttpGet]
        [Route("GetAddress/{id}")]
        public IActionResult GetAddress(int id)
        {
            try
            {
                var result = _address.GetById(id);
                return Ok(result);
            }
            catch
            {

                return BadRequest();
            }

        }



        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateAddress([FromBody] Address address)
        {
            try
            {

                var updateAddress = _address.Update(address);
                return Ok(updateAddress);

            }
            catch
            {

                return BadRequest();
            }

        }

        [HttpDelete]
        [Route("DeleteAddress/{id}")]
        public IActionResult DeleteAddress(int id)
        {
            try
            {
                _address.Remove(_address.GetById(id));
                return Ok("Address Silindi!");
            }
            catch
            {

                return BadRequest();
            }
        }

    }
}
