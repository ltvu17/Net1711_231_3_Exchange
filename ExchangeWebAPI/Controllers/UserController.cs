using ExchangeBusiness;
using ExchangeData;
using ExchangeData.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserBusiness _business;

        public UserController()
        {
            _business = new UserBusiness();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _business.GetAll();

            if (result.Status >0 )
            {
                return Ok(result.Data);
            }
            else
            {
                return NotFound(result.Message);
            }
        }


        [HttpGet]
        [Route("GetUser")]
        public async Task<IActionResult> GetUser(string id)
        {
            var result = await _business.GetByID(id);

            if (result.Status > 0)
            {
                return Ok(result.Data);
            }
            else
            {
                return NotFound(result.Message);
            }
        }

        [HttpPost]
        [Route("CreateUsers")]
        public async Task<IActionResult> CreateUsers( UserDTO user)
        {
            var result = await _business.CreateUser(user);

            if (result.Status > 0)
            {
                return Ok(result.Data);
            }
            else
            {
                return NotFound(result.Message);
            }
        }

        [HttpPut]
        [Route("UpdateUsers")]
        public async Task<IActionResult> UpdateUsers(UserDTO user)
        {
            var result = await _business.UpdateUser(user);

            if (result.Status > 0)
            {
                return Ok(result.Data);
            }
            else
            {
                return NotFound(result.Message);
            }
        }


        [HttpDelete]
        [Route("DeleteUsers")]
        public async Task<IActionResult> DeleteUsers(string id)
        {
            var result = await _business.DeleteUser(id);

            if (result.Status > 0)
            {
                return Ok(result.Data);
            }
            else
            {
                return NotFound(result.Message);
            }
        }





    }
}
