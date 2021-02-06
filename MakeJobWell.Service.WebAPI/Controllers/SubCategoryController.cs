using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.Models.Entities;
using MakeJobWell.Service.WebAPI.Models.SelfEntities;
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
    public class SubCategoryController : ControllerBase
    {
        ISubCategoryBLL subCategoryBLL;
        public SubCategoryController(ISubCategoryBLL subCategory)
        {
            subCategoryBLL = subCategory;
        }
        private List<SubCategoryDTO> GetSubCategories(ICollection<SubCategory> subCategories)
        {
            List<SubCategoryDTO> subCategoryDTOs = new List<SubCategoryDTO>();
            foreach (SubCategory item in subCategories)
            {
                subCategoryDTOs.Add(new SubCategoryDTO
                {
                    SubCategoryID = item.ID,
                    SubCategoryName = item.CategoryName,
                    Overview = item.Description,
                    CatName = item.Category.CategoryName
                });
            }
            return subCategoryDTOs;

        }

        public IActionResult GetAllSubCategories()
        {
            try
            {
                return Ok(GetSubCategories(subCategoryBLL.GetAll()));
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        public IActionResult GetAllSubCategoriesForAdmin()
        {
            try
            {
                return Ok(GetSubCategories(subCategoryBLL.GetAllWithCats()));
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetSubCategoriesWCats(int id)
        {
            try
            {
                return Ok(GetSubCategories(subCategoryBLL.GetSubCategoriesByCatID(id)));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            subCategoryBLL.Delete(id);
            return Ok();
        }

    }
}
