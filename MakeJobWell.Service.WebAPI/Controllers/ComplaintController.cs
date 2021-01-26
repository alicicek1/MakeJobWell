using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.Models.Entities;
using MakeJobWell.Service.WebAPI.Models;
using MakeJobWell.Service.WebAPI.Models.RelatedEntities;
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
    public class ComplaintController : ControllerBase
    {
        IComplaintBLL complaintBLL;
        public ComplaintController(IComplaintBLL complaint)
        {
            complaintBLL = complaint;
        }

        private List<ComplaintDTO> GetComplaints(ICollection<Complaint> complaints)
        {
            List<ComplaintDTO> complaintDTOs = new List<ComplaintDTO>();
            foreach (Complaint item in complaints)
            {
                complaintDTOs.Add(new ComplaintDTO
                {
                    ComplaintID = item.ID,
                    Title = item.ComplaintTitle,
                    Detail = item.ComplaintTitle,
                    CompanyID = item.CompanyID
                });
            }
            return complaintDTOs;
        }
        public IActionResult GetAllComplaints()
        {
            try
            {
                return Ok(GetComplaints(complaintBLL.GetAll()));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        public IActionResult GetComplaintForHomeIndex()
        {
            try
            {
                return Ok(GetComplaints(complaintBLL.GetTopSix()));
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetComplaintsWComments(int id)
        {
            try
            {
                Complaint complaint = complaintBLL.GetComplaintCompany(id);
                ComplaintCompanyDTO complaintCompanyDTO = new ComplaintCompanyDTO();
                complaintCompanyDTO.ComplaintID = complaint.ID;
                complaintCompanyDTO.Title = complaint.ComplaintTitle;
                complaintCompanyDTO.Detail = complaint.ComplaintDetail;
                complaintCompanyDTO.CompanyName = complaint.Company.CompanyName;
                return Ok(complaintCompanyDTO);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetComplaintByCompanyID(int id)
        {
            try
            {
                List<ComplaintDTO> complaintDTOs = new List<ComplaintDTO>();
                foreach (Complaint item in complaintBLL.GetComplaintsViaCompanyID(id))
                {
                    complaintDTOs.Add(new ComplaintDTO
                    {
                        ComplaintID = item.ID,
                        Title = item.ComplaintTitle,
                        Detail = item.ComplaintTitle,
                        CompanyID = item.CompanyID
                    });

                }
                return Ok(complaintDTOs);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetComplaintByUserID(int id)
        {
            try
            {
                List<ComplaintDTO> complaintDTOs = new List<ComplaintDTO>();
                foreach (Complaint item in complaintBLL.GetComplaintsByUserID(id))
                {
                    complaintDTOs.Add(new ComplaintDTO
                    {
                        ComplaintID = item.ID,
                        Title = item.ComplaintTitle,
                        Detail = item.ComplaintTitle,
                        CompanyID = item.CompanyID
                    });

                }
                return Ok(complaintDTOs);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult DeactivateComplaint(int id)
        {
            complaintBLL.Delete(complaintBLL.Get(id));
            return Ok();
        }

    }
}
