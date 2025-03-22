using Learning_management_system.DTO;
using Learning_management_system.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learning_management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizquestionController : ControllerBase
    {
        private readonly IQuizquestions _quizquestions;

        public QuizquestionController(IQuizquestions quizquestions)
        {
            _quizquestions = quizquestions;
        }
        [HttpGet]

        public async Task<IActionResult> Getallasync(int page = 1, int pagesize = 5, string searchterm = "")

        {
            try
            {
                var (result, totalcount) = await _quizquestions.Getallquizquestionasync(page, pagesize, searchterm);
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
                var message = _quizquestions.Deletequizquestionasync(id);
                return Ok(message);

            }
            catch (Exception ex)
            {
                return NotFound("error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateasync(int id, UpdateQuizquestionDTO updateQuizquestion)
        {
            try
            {
                var message = await _quizquestions.Updatequizquestionasync(updateQuizquestion, id);
                return Ok(message);

            }
            catch (Exception ex)
            {
                return NotFound("error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> createasync(CreateQuizquestionDTO createQuizquestion)
        {
            try
            {
                var message = _quizquestions.Createquizquestionasync(createQuizquestion);
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
                var result = await _quizquestions.Getviewquizquestionasync(Id);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return NotFound("error");
            }
        }
    }
}
