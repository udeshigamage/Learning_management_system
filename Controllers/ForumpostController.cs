using Learning_management_system.DTO;
using Learning_management_system.Interfaces;
using Learning_management_system.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learning_management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForumpostController : ControllerBase
    {
        private readonly IForumpostservice _forumpostservice;

        public ForumpostController(IForumpostservice forumpostservice)
        {
            _forumpostservice = forumpostservice;
        }
        [HttpGet]

        public async Task<IActionResult> Getallasync(int page = 1, int pagesize = 5, string searchterm = "")

        {
            try
            {
                var (result, totalcount) = await _forumpostservice.Getallasync(page, pagesize, searchterm);
                var result_ = new
                {
                    data = result,
                    totalItems = totalcount,
                    totalPages = (int)Math.Ceiling((double)totalcount / pagesize),
                    currentPage = page

                };
                return Ok(result_);


            }
            catch (Exception ex)
            {
                return NotFound("error");
            }

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Deleteasync(int id)
        {
            try
            {
                var message = _forumpostservice.Deleteforumpostasync(id);
                return Ok(message);

            }
            catch(Exception ex)
            {
                return NotFound("error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateasync(int id,UpdateForumpost updateForumpost)
        {
            try
            {
                var message = await _forumpostservice.Updateforumpostasync(updateForumpost,id);
                return Ok(message);

            }
            catch(Exception ex)
            {
                return NotFound("error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> createasync(CreateForumpost createForumpost)
        {
            try
            {
                var message = _forumpostservice.Createforumpostasync(createForumpost);
                return Ok(message);

            }
            catch(Exception ex)
            {
                return NotFound("error");   
            }
        }

        [HttpGet("{Id}")]

        public async Task<IActionResult> Getbyid(int Id)
        {
            try
            {
                var result = await _forumpostservice.Getviewforumpostasync(Id);
                return Ok(result);

            }
            catch(Exception ex)
            {
                return NotFound("error");
            }
        }
      



    }
}
