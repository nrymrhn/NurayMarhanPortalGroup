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
    public class ProductController : ControllerBase
    {
        private readonly IGenericService<Product> _product;

        public ProductController(IGenericService<Product> product)
        {
            _product = product;
        }



        [HttpGet]
        [Route("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            return Ok(_product.GetAll());
        }


        [HttpPost]
        [Route("[action]")]
        public IActionResult AddProduct([FromBody] Product product)
        {

            try
            {
                var addProduct = _product.Add(product);
                return Ok(addProduct);

            }
            catch (Exception)
            {

                return BadRequest();
            }

        }


        [HttpGet]
        [Route("GetProduct/{id}")]
        public IActionResult GetProduct(int id)
        {
            try
            {
                var result = _product.GetById(id);
                return Ok(result);
            }
            catch
            {

                return BadRequest();
            }

        }



        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            try
            {

                var updateProduct = _product.Update(product);
                return Ok(updateProduct);

            }
            catch
            {

                return BadRequest();
            }

        }

        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                _product.Remove(_product.GetById(id));
                return Ok("Ürün Silindi!");
            }
            catch
            {

                return BadRequest();
            }
        }
    }
}
