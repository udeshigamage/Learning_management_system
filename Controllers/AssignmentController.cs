using Learning_management_system.DTO;
using Learning_management_system.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learning_management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentservice;
        public AssignmentController(IAssignmentService assignmentservice)
        {
            _assignmentservice = assignmentservice;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAssignments(int page = 1, int pagesize = 5, string searchterm = "")
        {
            try
            {
                var (assignments, totalcount) = await _assignmentservice.Getallassignmentasync(page, pagesize, searchterm);
                var response = new
                {
                    data = assignments,
                    totalItems = totalcount,
                    totalPages = (int)Math.Ceiling((double)totalcount / pagesize),
                    currentPage = page

                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound("No assignments found");
            }

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssignment(int id)
        {
            try
            {
                var assignment = await _assignmentservice.Getviewassignmentasync(id);
                return Ok(assignment);
            }
            catch (Exception ex)
            {
                return NotFound("No assignment found");
            }
        }
        [HttpPost]
        public async Task<IActionResult> createassignment(CreateAssignmentDTO assignment)
        {
            try
            {
                var message = await _assignmentservice.Createassignmentasync(assignment);

                if (message.Status == "E")
                {
                    return BadRequest(message.Result);
                }
                return Ok(message.Result);

            }
            catch (Exception ex)
            {
                return NotFound("No assignments created");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> updateassignment(UpdateAssignmentDTO assignment, int id)
        {
            try
            {
                var message = await _assignmentservice.Updateassignmentasync(assignment, id);

                if (message.Status == "E")
                {
                    return BadRequest(message.Result);
                }
                return Ok(message.Result);
            }
            catch (Exception ex)
            {
                return NotFound("No assignments updated");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteassignment(int id)
        {
            try
            {
                var message = await _assignmentservice.Deleteassignmentasync(id);

                if (message.Status == "E")
                {
                    return BadRequest(message.Result);
                }
                return Ok(message.Result);
            }
            catch (Exception ex)
            {
                return NotFound("No assignments deleted");
            }
        }
    }
}
