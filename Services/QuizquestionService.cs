using Learning_management_system.dbcontext;
using Learning_management_system.DTO;
using Learning_management_system.Interfaces;
using Learning_management_system.Models;
using Microsoft.EntityFrameworkCore;

namespace Learning_management_system.Services
{
    public class QuizquestionService:IQuizquestions
    {
        private readonly Appdbcontext _context;
        public QuizquestionService(Appdbcontext context)
        {
            _context = context;
        }
        public async Task<Message<string>> Createquizquestionasync(CreateQuizquestionDTO quizquestion)
        {
            try
            {
                var quizquestions_ = new Quizquestions
                {
                    answertypes=quizquestion.answertypes,
                    Quiz_Id=quizquestion.Quiz_Id,
                    question_text=quizquestion.question_text,
                };

                _context.Quizquestions.Add(quizquestions_);
                await _context.SaveChangesAsync();
                return new Message<string>
                {
                    Status = "S",
                    Result = "Successfully created"
                };




               
            }
            catch (Exception ex)
            {
                return new Message<string>
                {
                    Status = "E",
                    Result = ex.Message
                };
            }
        }

        public async Task<Message<string>> Updatequizquestionasync(UpdateQuizquestionDTO quizquestion, int id)
        {
            try
            {
                var quizquestions = await _context.Quizquestions.FindAsync(id);
                if (quizquestions == null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "Error"
                    };

                }
                quizquestions.question_text = quizquestion.question_text;
                quizquestions.answertypes = quizquestion.answertypes;
                quizquestions.question_Id =quizquestion.question_Id;

                await _context.SaveChangesAsync();

                return new Message<string>
                {
                    Status = "S",
                    Result = "Successfully updated"
                };
            }
            catch (Exception ex)
            {
                return new Message<string>
                {
                    Status = "E",
                    Result = ex.Message
                };
            }

        }

        public async Task<Message<string>> Deletequizquestionasync(int id) {
            try
            {
                var quizquestions = await _context.Quizquestions.FindAsync(id);
                if(quizquestions == null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "Not found"
                    };
                }
                _context.Quizquestions.Remove(quizquestions);
                 await _context.SaveChangesAsync();

                return new Message<string>
                {
                    Status = "S",
                    Result = "Successfully deleted"
                };
            }
            catch (Exception ex)
            {
                return new Message<string>
                {
                    Status = "E",
                    Result = ex.Message
                };
            }
        }

        public async Task<IEnumerable<ViewQuizquestionDTO>> Getviewquizquestionasync(int id) {
            try
            {
                var quizquestion = await _context.Quizquestions.Where(c => c.question_Id == id).Select(c => new ViewQuizquestionDTO
                {
                    question_Id = c.question_Id,
                    answertypes = c.answertypes,
                    question_text  = c.question_text,
                    Quiz_Id = c.Quiz_Id


                }).ToListAsync();

                return quizquestion;
            }
            catch (Exception ex)
            {
                throw new Exception("error");
            }
        }

        public async Task<(IEnumerable<ViewQuizquestionDTO>, int totalcount)> Getallquizquestionasync(int page = 1, int pagesize = 5, string searchterm = "")
        {
            try
            {
                var query =  _context.Quizquestions.AsQueryable();

                if(!string.IsNullOrEmpty(searchterm))
                {
                    
                    query = query.Where(c => c.question_text.Contains(searchterm));
                }
           
                var totalcount = query.Count();
                var result = query.Skip((page - 1) * pagesize).Take(pagesize).Select(c => new ViewQuizquestionDTO
                {
                    question_Id = c.question_Id,
                    answertypes = c.answertypes,
                    question_text = c.question_text,
                    Quiz_Id = c.Quiz_Id


                }).ToList();

                return(result,totalcount);
            }
            catch (Exception ex)
            {
                throw new Exception("error");
            }
        }

    }
}
