using Learning_management_system.DTO;
using Learning_management_system.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learning_management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly    IEnrollmentservice _enrollmentservice;
        public EnrollmentController(IEnrollmentservice enrollmentservice)
        {
            _enrollmentservice = enrollmentservice;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEnrollments(int page = 1, int pagesize = 5, string searchterm = "")
        {
            try
            {
                var (enrollments, totalcount) = await _enrollmentservice.Getallenrollmentasync(page, pagesize, searchterm);
                var response = new
                {
                    data = enrollments,
                    totalItems = totalcount,
                    totalPages = (int)Math.Ceiling((double)totalcount / pagesize),
                    currentPage = page

                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound("No enrollments found");
            }

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnrollment(int id)
        {
            try
            {
                var enrollment = await _enrollmentservice.Getviewenrollmentasync(id);
                return Ok(enrollment);
            }
            catch (Exception ex)
            {
                return NotFound("No enrollment found");
            }

        }
        [HttpPost]
        public async Task<IActionResult> CreateEnrollment(CreateEnrollmentDTO enrollment)
        {
            try
            {
                var message = await _enrollmentservice.Createenrollmentasync(enrollment);

                if (message.Status == "E")
                {
                    return BadRequest(message.Result);
                }
                return Ok(message.Result);

            }
            catch (Exception ex)
            {
                return NotFound("No enrollments created");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            try
            {
                var message = await _enrollmentservice.Deleteenrollmentasync(id);

                if (message.Status == "E")
                {
                    return BadRequest(message.Result);
                }
                return Ok(message.Result);

            }
            catch (Exception ex)
            {
                return NotFound("No enrollments deleted");
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEnrollment(UpdateEnrollmentDTO enrollment, int id)
        {
            try
            {
                var message = await _enrollmentservice.Updateenrollmentasync(enrollment, id);

                if (message.Status == "E")
                {
                    return BadRequest(message.Result);
                }
                return Ok(message.Result);

            }
            catch (Exception ex)
            {
                return NotFound("No enrollments updated");
            }
        }
        
    }
}
