using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.Models.Entities;
using MakeJobWell.Service.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MakeJobWell.Service.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryBLL categoryBLL;
        public CategoryController(ICategoryBLL category)
        {
            categoryBLL = category;
        }
        [HttpGet]
        private List<CategoryDTO> GetCategories(ICollection<Category> categories)
        {
            List<CategoryDTO> categoryDTOs = new List<CategoryDTO>();
            foreach (Category item in categories)
            {
                categoryDTOs.Add(new CategoryDTO
                {
                    CategoryID = item.ID,
                    CategoryName = item.CategoryName,
                    Overview = item.Description
                });
            }
            return categoryDTOs;

        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            var result = categoryBLL.Add(category);
            if (result.Succes)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        public IActionResult GetCategories()
        {
            try
            {
                return Ok(GetCategories(categoryBLL.GetAll().Data));
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        public IActionResult GetCategoriesForHomeIndex()
        {
            try
            {
                return Ok(GetCategories(categoryBLL.GetLatestSix().Data));
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCategorByID(int id)
        {
            try
            {
                Category category = categoryBLL.Get(id).Data;

                CategoryDTO categoryDTO = new CategoryDTO()
                {
                    CategoryID = category.ID,
                    CategoryName = category.CategoryName
                };
                return Ok(categoryDTO);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            categoryBLL.Delete(id);
            return Ok();
        }
    }
}
