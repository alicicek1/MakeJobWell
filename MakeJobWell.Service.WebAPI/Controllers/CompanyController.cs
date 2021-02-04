using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.Models.Entities;
using MakeJobWell.Service.WebAPI.Models.SelfEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeJobWell.Service.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        ICompanyBLL companyBLL;
        public CompanyController(ICompanyBLL company)
        {
            companyBLL = company;
        }

        private List<CompanyDTO> GetCompanies(ICollection<Company> companies)
        {
            List<CompanyDTO> companyDTOs = new List<CompanyDTO>();
            foreach (Company item in companies)
            {
                companyDTOs.Add(new CompanyDTO
                {
                    CompanyID = item.ID,
                    CompanyName = item.CompanyName,
                    Overview = item.Overview,
                    Location = item.Location,
                    WebSite = item.WebSite
                });
            }
            return companyDTOs;
        }

        public IActionResult GetAllCompanies()
        {
            try
            {
                return Ok(GetCompanies(companyBLL.GetAll()));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{letter}")]
        public IActionResult GetAllCompaniesByFLetter(string letter)
        {
            try
            {
                return Ok(GetCompanies(companyBLL.GetCompaniesByFLetter(letter)));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        public IActionResult GetCompaniesForHomeIndex()
        {
            try
            {
                return Ok(GetCompanies(companyBLL.GetTopSix()));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCompanyByID(int id)
        {
            try
            {
                Company company = companyBLL.Get(id);
                CompanyDTO companyDTO = new CompanyDTO()
                {
                    CompanyID = company.ID,
                    CompanyName = company.CompanyName,
                    Overview = company.Overview,
                    Location = company.Location,
                    WebSite = company.WebSite
                };
                return Ok(companyDTO);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);

            }
        }

        [HttpGet("{letter}")]
        public IActionResult GetCompaniesByFLetter(string letter)
        {
            try
            {
                List<Company> companies = companyBLL.GetCompaniesByFLetter(letter).ToList();
                List<CompanyDTO> companyDTOs = new List<CompanyDTO>();
                foreach (Company item in companies)
                {
                    companyDTOs.Add(new CompanyDTO
                    {
                        CompanyID = item.ID,
                        CompanyName = item.CompanyName,
                        Overview = item.Overview,
                        Location = item.Location,
                        WebSite = item.WebSite
                    });
                }
                return Ok(companyDTOs);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            companyBLL.Delete(id);
            return Ok();
        }


    }
}
