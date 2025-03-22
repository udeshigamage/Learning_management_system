using Learning_management_system.DTO;
using Learning_management_system.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learning_management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementservice _announcementservice;

        public AnnouncementController(IAnnouncementservice announcementservice)
        {
            _announcementservice = announcementservice;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnnouncements(int page = 1, int pagesize = 5, string searchterm = "")
        {
            try
            {
                var (announcements, totalcount) = await _announcementservice.Getallannouncementasync(page, pagesize, searchterm);
                var response = new
                {
                    data = announcements,
                    totalItems = totalcount,
                    totalPages = (int)Math.Ceiling((double)totalcount / pagesize),
                    currentPage = page

                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound("No announcements found");
            }

        }

        [HttpPost]

        public async Task<IActionResult> createannouncement(CreateAnnouncementDTO announcement)
        {
            try
            {
                var message= await _announcementservice.Createannouncementasync(announcement);

                if (message.Status == "E")
                {
                    return BadRequest(message.Result);
                }
                return Ok(message.Result);

            }
            catch (Exception ex)
            {
                return NotFound("No announcements created");
            }

        }

        [HttpPut("{id}")]

        public async Task<IActionResult> updateannouncement (UpdateAnnouncementDTO announcement,int id)
        {
            try
            {
                var message = await _announcementservice.Updateannouncementasync(announcement, id);

                if (message.Status == "E")
                {
                    return BadRequest(message.Result);
                }
                return Ok(message.Result);

            }
            catch (Exception ex)
            {
                return NotFound("No announcements updated");
            }
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Deleteannouncement(int id)
        {
            try
            {
                var message = await _announcementservice.Deleteannouncementasync(id);

                if (message.Status == "E")
                {
                    return BadRequest(message.Result);
                }
                return Ok(message.Result);

            }
            catch (Exception ex)
            {
                return NotFound("No announcements deleted");
            }

        }
        [HttpGet("{id}")]

        public async Task<IActionResult> getbyid(int id)
        {
            try
            {
                var announcement = await _announcementservice.Getviewannouncementasync(id);
                return Ok(announcement);

            }
            catch (Exception ex)
            {
                throw new Exception("Announcement not found");
            }

        }
    }
}
