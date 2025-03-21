using Learning_management_system.dbcontext;
using Learning_management_system.DTO;
using Learning_management_system.Interfaces;
using Learning_management_system.Models;
using Microsoft.EntityFrameworkCore;

namespace Learning_management_system.Services
{
    public class QuizresultService:IQuizresultservice
    {
        private readonly Appdbcontext _context;
        public QuizresultService(Appdbcontext context)
        {
            _context = context;
        }
        public async Task<Message<string>> Createquizresultasync(CreateQuizresultDTO quizresult)
        {
            try
            {
                var quizresult_ = new Quizresult
                {
                    User_Id=quizresult.User_Id,
                    Quiz_Id=quizresult.Quiz_Id,
                    Score =quizresult.Score,
                    datetaken = DateTime.Now


                };

                _context.Quizresult.Add(quizresult_);
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

        public async Task<Message<string>> Updatequizresultasync(UpdateQuizresultDTO quizresult, int id)
        {
            try
            {
                var existingquizresult = await _context.Quizresult.FindAsync(id);

               if( existingquizresult == null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "Error"
                    };

                }
                existingquizresult.Score = quizresult.Score;
                existingquizresult.User_Id = quizresult.User_Id;
                existingquizresult.Quiz_Id = quizresult.Quiz_Id;

                _context.SaveChangesAsync();




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

        public async Task<Message<string>> Deletequizresultasync(int id)
        {
            try
            {
                var quizresult = await _context.Quizresult.FindAsync( id);
                if (quizresult == null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "Not found"
                    };
                }
                 _context.Quizresult.Remove(quizresult);

                await _context.SaveChangesAsync();
                return new Message<string>
                {
                    Status = "S",
                    Result = "Successfully Deleted"
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

        public async Task<IEnumerable<ViewQuizresultDTO>> Getviewquizresultasync(int id)
        {
            try
            {
                var quizresult = await _context.Quizresult.Where(c => c.result_Id == id).Select(c => new ViewQuizresultDTO
                {
                    Quiz_Id = c.Quiz_Id,
                    User_Id = c.User_Id,
                    datetaken = c.datetaken,
                    Score = c.Score,
                    result_Id = c.result_Id,
                    





                }).ToListAsync();
                return quizresult;
            }
            catch (Exception ex)
            {
                throw new Exception("error");
            }
        }

        public async Task<(IEnumerable<ViewQuizresultDTO>, int totalcount)> Getallquizresultasync(int page = 1, int pagesize = 5, string searchterm = "", string filterBy = "", string filterValue = "")
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw new Exception("error");
            }
        }


    }
}
