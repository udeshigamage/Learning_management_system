using Learning_management_system.dbcontext;
using Learning_management_system.DTO;
using Learning_management_system.Interfaces;
using Learning_management_system.Models;
using Microsoft.EntityFrameworkCore;

namespace Learning_management_system.Services
{
    public class QuizService:IQuizesservice
    {
        private readonly Appdbcontext _context;

        public QuizService(Appdbcontext context)
        {
            _context = context;
        }
        public async Task<Message<string>> Createquizasync(CreateQuizDTO quiz)
        {
            try
            {
                var quiz_ = new Quizes
                {
                    Course_Id= quiz.Course_Id,
                    Quiz_Name =quiz.Quiz_Name,
                    Createddate = DateTime.Now,




                };
                _context.Quizes.Add(quiz_);
                await _context.SaveChangesAsync();
                return new Message<string>
                {
                    Status = "S",
                    Result = "Success"

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

        public async Task<Message<string>> Updatequizasync(UpdateQuizDTO quiz, int id) {
            try
            {
                var existingquiz = await _context.Quizes.FindAsync(id);

                if(existingquiz == null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "Error"
                    };
                }

                existingquiz.Quiz_Name = quiz.Quiz_Name;
                existingquiz.Course_Id =quiz.Course_Id;

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

        public async Task<Message<string>> Deletequizasync(int id) {
            try
            {
                var quiz = await _context.Quizes.FindAsync(id);
                if(quiz == null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "Not found"
                    };
                }
                _context.Quizes.Remove(quiz);
                await _context.SaveChangesAsync();
                return new Message<string>
                {
                    Status = "S",
                    Result = "deleted successfully"
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

        public async Task<IEnumerable<ViewQuizDTO>> Getviewquizasync(int id) {
            try
            {
                var quiz = await _context.Quizes.Where(c => c.Quiz_Id == id).Select(c => new ViewQuizDTO
                {
                    Course_Id= c.Course_Id,
                    Createddate=c.Createddate,
                    Quiz_Name =c.Quiz_Name,
                    Quiz_Id = c.Quiz_Id



                }).ToListAsync();
                return quiz;
            }
            catch (Exception ex)
            {
                throw new Exception("error");
            }
        }

        public async Task<(IEnumerable<ViewQuizDTO>, int totalcount)> Getallquizasync(int page = 1, int pagesize = 5, string searchterm = "", string filterBy = "", string filterValue = "")
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw new Exception("error");
            }
        }

        public async Task<IEnumerable<ListQuizDTO>> GetListquizasync()
        {
            try
            {
                var quiz = await _context.Quizes.Select(c => new ListQuizDTO
                {
                    Quiz_Name = c.Quiz_Name,
                    Quiz_Id = c.Quiz_Id,

                }).ToListAsync();

                return quiz;
            }
            catch (Exception ex)
            {
                throw new Exception("error");
            }
        }
    }
}
