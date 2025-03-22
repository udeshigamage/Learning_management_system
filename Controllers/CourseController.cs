using Learning_management_system.DTO;
using Learning_management_system.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Learning_management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        
        [HttpGet]
        public async Task<IActionResult>  GetAllcourse(int page=1,int pagesize=5,string searchterm="",string filterBy="",string filterValue="" )
        {
            try
            {
                var (courses, totalcount) = await _courseService.Getallasync(page, pagesize, searchterm, filterBy, filterValue);
                var response = new
                {
                    data = courses,
                    totalItems = totalcount,
                    totalPages = (int)Math.Ceiling((double)totalcount / pagesize),
                    currentPage = page

                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound("No courses found");
            }
           
        }

        [HttpGet("/courses/list")]

        public async Task<IActionResult> Getlistcourses()
        {
            try
            {
                var list_courses = await _courseService.GetListcourseasync();
                return Ok(list_courses);

            }
            catch (Exception ex)
            {

                throw new Exception("error in controller");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Getbyid(int id)
        {
           try
            {
                var course = await _courseService.Getviewcourseasync(id);
                return Ok(course);
            }
            catch (Exception ex)
            {
                throw new Exception("Course not found");
            }
        }
        [Authorize(Roles = "Admin,Teacher")] 
        [HttpPost]
        public async Task<IActionResult> createcourse([FromBody] CreateCourseDTO createCourseDTO)
        {
            try
            {
                var message = await _courseService.Createcourseasync(createCourseDTO);
                return Ok(message);

            }
            catch (Exception ex)
            {
                throw new Exception("Course not created");
            }
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> Updatecourse(int id, [FromBody] UpdateCourseDTO updateCourseDTO)
        {
            try
            {
                var message = await _courseService.Updatecourseasync(updateCourseDTO,id);
                return Ok(message);

            }
            catch (Exception ex)
            {
                throw new Exception("Course not found");
            }
        }

        
        [HttpDelete("{id}")]
       public async Task<IActionResult> Deletecourse(int id)
        {
            try
            {
                var message= await _courseService.Deletecourseasync(id);
                return Ok(message);

            }catch(Exception ex)
            {
                throw new Exception("Course not found");
            }

        }
    }
}
