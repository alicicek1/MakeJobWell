using MakeJobWell.BLL.Abstract.IRepositorories;
using MakeJobWell.Models.Entities;
using MakeJobWell.Service.WebAPI.Models.SelfEntities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MakeJobWell.Service.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBLL userBLL;
        public UserController(IUserBLL bLL)
        {
            userBLL = bLL;
        }

        [HttpGet("{id}")]
        public IActionResult GetUserByID(int id)
        {
            User user = userBLL.Get(id).Data;
            UserDTO userDTO = new UserDTO()
            {
                IDDTO = user.ID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                Password = user.Password,
                Gender = user.Gender
            };
            return Ok(userDTO);
        }

        [HttpGet]
        public IActionResult GetAllUser()
        {
            try
            {
                return Ok(userBLL.GetAll().Data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{UserName}")]
        public IActionResult Delete(string UserName)
        {
            userBLL.DeleteByUserName(UserName);
            return Ok();
        }

    }
}
