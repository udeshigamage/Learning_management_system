using Castle.Core.Resource;
using Learning_management_system.DTO;
using Learning_management_system.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learning_management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase


    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllviewusersasync(int page = 1, int pagesize = 5,string searchterm="", string filterValue="" , string filterBy ="" )
        {
            try
            {
                var( users,totalcount) = await _userService.GetAllviewusersasync(page, pagesize, searchterm,filterValue,filterBy);

                var response = new
                {
                    data = users,
                    totalItems = totalcount,
                    totalPages = (int)Math.Ceiling((double)totalcount / pagesize),
                    currentPage = page
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception("No users found");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Getviewuserasync(int id)
        {
            try
            {
                var user = await _userService.Getviewuserasync(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                throw new Exception("User not found");
            }
        }


        [HttpPost]
    public async Task<IActionResult> Createuserasync([FromBody] CreateUserDTO user)
        {
            try
            {
                var message= await _userService.Createuserasync(user);
                return Ok(message);

            }
            catch (Exception ex) {
                throw new Exception("Creating user failed");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecustomerasync(int id)
        {
            try
            {
                var message= await _userService.Deleteuserasync(id);
                return Ok(message);

            }
            catch(Exception ex)
            {
               throw new Exception(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Updatecustomerasync(int id,UpdateUserDTO user)
        {
            try
            {
                var message = await _userService.Updateuserasync(user, id);
                return Ok(message);
            }
            catch(Exception ex)
            {

            throw new Exception(ex.Message); }
            

        }



    }
}
