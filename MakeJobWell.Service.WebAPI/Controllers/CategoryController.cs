using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.Models.Entities;
using MakeJobWell.Service.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public IActionResult GetCategories()
        {
            try
            {
                return Ok(GetCategories(categoryBLL.GetAll()));
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
                return Ok(GetCategories(categoryBLL.GetLatestSix()));
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
                Category category = categoryBLL.Get(id);

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
    }
}
