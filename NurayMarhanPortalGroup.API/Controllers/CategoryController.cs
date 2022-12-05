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
    public class CategoryController : ControllerBase
    {
        private readonly IGenericService<Category> _category;

        public CategoryController(IGenericService<Category> category)
        {
            _category = category;
        }


        [HttpGet]
        [Route("GetAllCategories")]
        public IActionResult GetAllCategories()
        {
            return Ok(_category.GetAll());
        }



        [HttpPost]
        [Route("[action]")]
        public IActionResult AddCategory([FromBody] Category category)
        {


            try
            {
                var addCategory = _category.Add(category);
                return Ok(addCategory);

            }
            catch
            {

                return BadRequest();
            }


        }


        [HttpGet]
        [Route("GetCategory/{id}")]
        public IActionResult GetCategory(int id)
        {
            try
            {
                var result = _category.GetById(id);
                return Ok(result);
            }
            catch
            {

                return BadRequest();
            }

        }



        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateCategory([FromBody] Category category)
        {
            try
            {

                var updateCategory = _category.Update(category);
                return Ok(updateCategory);

            }
            catch
            {

                return BadRequest();
            }

        }

        [HttpDelete]
        [Route("DeleteCategory/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                _category.Remove(_category.GetById(id));
                return Ok("Kategori Silindi!");
            }
            catch
            {

                return BadRequest();
            }
        }
    }
}
