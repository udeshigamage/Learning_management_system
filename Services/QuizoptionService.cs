using Learning_management_system.dbcontext;
using Learning_management_system.DTO;
using Learning_management_system.Interfaces;
using Learning_management_system.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Learning_management_system.Services
{
    public class QuizoptionService:IQuizoptionsservice
    {
        private readonly Appdbcontext _context;

        public QuizoptionService(Appdbcontext context)
        {
            _context = context;
        }
        public async Task<Message<string>> Createquizoptionasync(CreateQuizoptionDTO quizoption) {
            try
            {
                var quizoption_ = new Quizoptions
                {
                    Question_Id =quizoption.Question_Id,
                    Is_correct= quizoption.Is_correct,
                    Option_text = quizoption.Option_text,




                };
                _context.Quizoptions.Add(quizoption_);
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

        public async Task<Message<string>> Updatequizoptionasync(UpdateQuizoptionDTO quizoption, int id) {
            try
            {
                var existingquizoption = await _context.Quizoptions.FindAsync(id);
                if(existingquizoption== null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "Error"
                    };

                }
                existingquizoption.Option_text = quizoption.Option_text;
                existingquizoption.Question_Id = quizoption.Question_Id;
                existingquizoption.Is_correct = quizoption.Is_correct;

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

        public async Task<Message<string>> Deletequizoptionasync(int id) {
            try
            {
                var quizoptions = await _context.Quizoptions.FindAsync(id);
                if(quizoptions == null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "NOTfound"
                    };

                }
                _context.Quizoptions.Remove(quizoptions);
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

        public async Task<IEnumerable<ViewQuizoptionDTO>> Getviewquizoptionasync(int id) {
            try
            {
                var quizoptions = await _context.Quizoptions.Where(c => c.Option_Id == id).Select(c => new ViewQuizoptionDTO
                {
                    Option_Id = c.Option_Id,
                    Question_Id = c.Question_Id,
                    Is_correct = c.Is_correct,
                    Option_text = c.Option_text,


                }).ToListAsync();

                return (quizoptions);
            }
            catch (Exception ex)
            {
                throw new Exception("error ");
            }
        }

        public async Task<(IEnumerable<ViewQuizoptionDTO>, int totalcount)> Getallquizoptionasync(int page = 1, int pagesize = 5, string searchterm = "", string filterBy = "", string filterValue = "") {
            try
            {
                var query = _context.Quizoptions.AsQueryable();
                if (!string.IsNullOrEmpty(searchterm))
                {
                    query = query.Where(c => c.Option_text.Contains(searchterm));
                }

                var totalcount = query.Count();
                var result = await query .Skip((page-1)*pagesize).Skip(pagesize).Select(c => new ViewQuizoptionDTO
                {
                    Option_Id = c.Option_Id,
                    Question_Id = c.Question_Id,
                    Is_correct = c.Is_correct,
                    Option_text = c.Option_text,

                }).ToListAsync();

                return (result, totalcount);
            }
            catch (Exception ex)
            {
                throw new Exception("error");
            }
        }

        public async Task<IEnumerable<ListQuizoptionDTO>> GetListquizoptionasync()
        {
            try
            {
                var optionlist = await _context.Quizoptions.Select(c => new ListQuizoptionDTO
                {
                    Option_text = c.Option_text,
                    Option_Id = c.Option_Id


                }).ToListAsync();
                return (optionlist);
                
            }
            catch (Exception ex)
            {
                throw new Exception("error");
            }
        }
    }
}
