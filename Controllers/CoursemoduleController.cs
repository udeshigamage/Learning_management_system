using Learning_management_system.DTO;
using Learning_management_system.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learning_management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursemoduleController : ControllerBase
    {
        private readonly ICoursemoduleService _coursemoduleService;
        public CoursemoduleController(ICoursemoduleService coursemoduleService)
        {
            _coursemoduleService = coursemoduleService;
        }

        [HttpGet]
        public async Task<IActionResult> Getallmodules(int page=1,int pagesize=5,string searchterm="")
        {
            try
            {
                var (modules,totalcount)= await _coursemoduleService.getallcoursemodules(page,pagesize,searchterm);
                var response = new
                {
                    data = modules,
                    totalPages = (int)Math.Ceiling((double)totalcount / pagesize),
                    currentPage = page,
                    totalitems=totalcount,

                };
                return Ok(response);

            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Getmodulesbyid(int id)
        {
            try
            {
                var modules = await _coursemoduleService.getcoursemodulebyid(id);
                return Ok(modules);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> createmodules(createCoursemoduleDTO createCoursemodule)
        {
            try
            {
                var message = await _coursemoduleService.CreatecoursemoduleAsync(createCoursemodule);
                return Ok(message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete ("{id}")]
        public async Task<IActionResult> Deletemodule(int id)
        {
            try
            {
                var message = await _coursemoduleService.deletecoursemodule(id);
                return Ok(message);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("/coursemodule/list")]
        public async Task<IActionResult> Getallmoduleslist()
        {
            try
            { 
                var modules = await _coursemoduleService.listcoursemodule();
                return Ok(modules);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
