using Learning_management_system.DTO;
using Learning_management_system.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learning_management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizoptionController : ControllerBase
    {
        private readonly IQuizoptionsservice _quizoptionsservice;

        public QuizoptionController(IQuizoptionsservice quizoptionsservice)
        {
            _quizoptionsservice= quizoptionsservice;
        }
        [HttpGet]

        public async Task<IActionResult> Getallasync(int page = 1, int pagesize = 5, string searchterm = "")

        {
            try
            {
                var (result, totalcount) = await _quizoptionsservice.Getallquizoptionasync(page, pagesize, searchterm);
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
                var message = _quizoptionsservice.Deletequizoptionasync(id);
                return Ok(message);

            }
            catch (Exception ex)
            {
                return NotFound("error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateasync(int id, UpdateQuizoptionDTO updateQuizoption)
        {
            try
            {
                var message = await _quizoptionsservice.Updatequizoptionasync(updateQuizoption, id);
                return Ok(message);

            }
            catch (Exception ex)
            {
                return NotFound("error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> createasync(CreateQuizoptionDTO createQuizquestion)
        {
            try
            {
                var message = _quizoptionsservice.Createquizoptionasync(createQuizquestion);
                return Ok(message);

            }
            catch (Exception ex)
            {
                return NotFound("error");
            }
        }

        [HttpGet("{Id}")]

        public async Task<IActionResult> Getbyid(int Id)
        {
            try
            {
                var result = await _quizoptionsservice.Getviewquizoptionasync(Id);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return NotFound("error");
            }
        }
    }
}
