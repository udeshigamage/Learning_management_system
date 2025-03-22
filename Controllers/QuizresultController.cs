using Learning_management_system.DTO;
using Learning_management_system.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learning_management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizresultController : ControllerBase
    {
        private readonly IQuizresultservice _quizresultservice;

        public QuizresultController(IQuizresultservice quizresultservice)
        {
           _quizresultservice = quizresultservice;
        }
        [HttpGet]

        public async Task<IActionResult> Getallasync(int page = 1, int pagesize = 5, string searchterm = "")

        {
            try
            {
                var (result, totalcount) = await  _quizresultservice.Getallquizresultasync(page, pagesize, searchterm);
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
                var message =  _quizresultservice.Deletequizresultasync(id);
                return Ok(message);

            }
            catch (Exception ex)
            {
                return NotFound("error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateasync(int id, UpdateQuizresultDTO updateQuizresult)
        {
            try
            {
                var message = await  _quizresultservice.Updatequizresultasync(updateQuizresult, id);
                return Ok(message);

            }
            catch (Exception ex)
            {
                return NotFound("error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> createasync(CreateQuizresultDTO createQuizresult)
        {
            try
            {
                var message =  _quizresultservice.Createquizresultasync(createQuizresult);
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
                var result = await _quizresultservice.Getviewquizresultasync(Id);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return NotFound("error");
            }
        }
    }
}
