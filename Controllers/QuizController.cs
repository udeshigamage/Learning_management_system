using Learning_management_system.DTO;
using Learning_management_system.Interfaces;
using Learning_management_system.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learning_management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizesservice _quizesservice;

        public QuizController (IQuizesservice quizesservice)
        {
            _quizesservice = quizesservice;
        }

        [HttpGet]

        public async Task<IActionResult> Getallasync(int page = 1, int pagesize = 5, string searchterm = "")

        {
            try
            {
                var (result, totalcount) = await _quizesservice.Getallquizasync(page, pagesize, searchterm);
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
                var message = _quizesservice.Deletequizasync(id);
                return Ok(message);

            }
            catch (Exception ex)
            {
                return NotFound("error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateasync(int id, UpdateQuizDTO updateQuiz)
        {
            try
            {
                var message = await _quizesservice.Updatequizasync(updateQuiz, id);
                return Ok(message);

            }
            catch (Exception ex)
            {
                return NotFound("error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> createasync(CreateQuizDTO createQuizquestion)
        {
            try
            {
                var message = _quizesservice.Createquizasync(createQuizquestion);
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
                var result = await _quizesservice.Getviewquizasync(Id);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return NotFound("error");
            }
        }
    }
}
