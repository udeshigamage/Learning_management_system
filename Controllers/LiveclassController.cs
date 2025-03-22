using Learning_management_system.DTO;
using Learning_management_system.Interfaces;
using Learning_management_system.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Learning_management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiveclassController : ControllerBase
    {
        private readonly ILiveclassService _liveclassService;

        public LiveclassController(ILiveclassService liveclassService)
        {

            _liveclassService = liveclassService;

        }
        [HttpGet]

        public async Task<IActionResult> Getallasync(int page=1,int pagesize=5,string searchterm="")
        {
            try
            {
                var (result, totalcount) = await _liveclassService.Getallliveclassesasync(page, pagesize, searchterm);
                var result_ = new
                {
                    data = result,
                    totalItems = totalcount,
                    totalPages = (int)Math.Ceiling((double)totalcount / pagesize),
                    currentPage = page

                };
                return Ok(result_);

            }
            catch(Exception ex)
            {
                return NotFound("Error");
            }

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Getbyid(int id)
        {
            try
            {
                var liveclass = await _liveclassService.Getviewliveclassesasync(id);
                return Ok(liveclass);

            }catch(Exception ex)
            {
                return NotFound("error");
            }


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteasync(int id)
        {
            try
            {
                var message = await _liveclassService.Deleteliveclassesasync(id);
                return Ok(message);

            }
            catch (Exception ex)
            {
                return NotFound("error");
            }


        }
        [HttpPost]

        public async Task<IActionResult> Createasync(CreateLiveclassesDTO createLiveclassesDTO)

        {
            try
            {
                var message = await _liveclassService.Createliveclassesasync(createLiveclassesDTO);
                return Ok(message);

            }
            catch(Exception ex)
            {
                return NotFound("error");
            }

        }
        [HttpPut("{id}")]

        public async Task<IActionResult> Updateasync(int id, UpdateLiveclassesDTO updateLiveclasses)
        {
            try
            {
                var message = _liveclassService.Updateliveclassesasync(updateLiveclasses, id);
                    return Ok(message);

            }
            catch (Exception ex)
            {
                return NotFound("error");
            }
        }

     


    }
}
