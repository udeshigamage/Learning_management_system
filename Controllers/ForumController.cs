using Learning_management_system.DTO;
using Learning_management_system.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learning_management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForumController : ControllerBase
    {
        private readonly IForumservice _forumservice;

        public ForumController(IForumservice forumservice)
        {
            _forumservice = forumservice;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllForums(int page = 1, int pagesize = 5, string searchterm = "")
        {
            try
            {
                var (forums, totalcount) = await _forumservice.Getallforumasync(page, pagesize, searchterm);
                var response = new
                {
                    data = forums,
                    totalItems = totalcount,
                    totalPages = (int)Math.Ceiling((double)totalcount / pagesize),
                    currentPage = page

                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound("No forums found");
            }

        }
        [HttpPost]
        public async Task<IActionResult> CreateForum(CreateForumDTO forum)
        {
            try
            {
                var message = await _forumservice.Createforumasync(forum);

                if (message.Status == "E")
                {
                    return BadRequest(message.Result);
                }
                return Ok(message.Result);

            }
            catch (Exception ex)
            {
                return NotFound("No forums created");
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateForum(UpdateForumDTO forum, int id)
        {
            try
            {
                var message = await _forumservice.Updateforumasync(forum, id);

                if (message.Status == "E")
                {
                    return BadRequest(message.Result);
                }
                return Ok(message.Result);

            }
            catch (Exception ex)
            {
                return NotFound("No forums updated");
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetForum(int id)
        {
            try
            {
                var forum = await _forumservice.Getviewforumasync(id);
                return Ok(forum);
            }
            catch (Exception ex)
            {
                return NotFound("No forum found");
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteForum(int id)
        {
            try
            {
                var message = await _forumservice.Deleteforumasync(id);

                if (message.Status == "E")
                {
                    return BadRequest(message.Result);
                }
                return Ok(message.Result);
            }
            catch (Exception ex)
            {
                return NotFound("No forums deleted");
            }
        }
    }
}
