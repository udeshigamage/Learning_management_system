using Learning_management_system.dbcontext;
using Learning_management_system.DTO;
using Learning_management_system.Interfaces;
using Learning_management_system.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Learning_management_system.Services
{
    public class SubmissionService:ISubmissionsService
    {
        private readonly Appdbcontext _context;

        public SubmissionService(Appdbcontext context)
        {
            _context = context;
        }
        public async Task<Message<string>> Createsubmissionasync(CreateSubmissionDTO submission)
        {
            try
            {
                var newsubmission = new Submission
                {
                    feedback = submission.feedback,
                    filepaths = submission.filepaths,
                    grade =submission.grade,
                    Assignment_Id=submission.Assignment_Id,
                    User_Id=submission.User_Id,
                    submission_date= DateTime.UtcNow




                };
                _context.Submissions.Add(newsubmission);
                await _context.SaveChangesAsync();
                return new Message<string>
                {
                    Result="successfull",
                    Status="S",
                    

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

        public async Task<Message<string>> Updatesubmissionasync(UpdateSubmissionDTO submission, int id)
        {
            try
            {
                var existingsubmission = await _context.Submissions.FindAsync(id);
                if(existingsubmission == null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "Error"
                    };
                }
                existingsubmission.feedback = submission.feedback;
                existingsubmission.filepaths =submission.filepaths;
                existingsubmission.grade = submission.grade;    
                existingsubmission.Assignment_Id = submission.Assignment_Id;
                existingsubmission.User_Id = submission.User_Id;

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

        public async Task<Message<string>> Deletesubmissionasync(int id)
        {
            try
            {
                var submission = await _context.Submissions.FindAsync(id);
                if (submission == null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "Not found"
                    };
                }
                _context.Submissions.Remove(submission);
                await _context.SaveChangesAsync();
                return new Message<string>
                {
                    Status = "S",
                    Result = "Deleted Successfully"
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

        public async Task<IEnumerable<ViewSubmissionDTO>> Getviewsubmissionasync(int id)
        {
            try
            {
                var submission = await _context.Submissions.Where(c => c.Submission_Id == id).Select(c => new ViewSubmissionDTO
                {
                    Submission_Id = c.Submission_Id,
                    Assignment_Id= c.Assignment_Id,
                    User_Id= c.User_Id,
                    feedback=c.feedback,
                    filepaths=c.filepaths,
                    grade=c.grade,
                    submission_date= c.submission_date



                }).ToListAsync();

                return (submission);

            }
            catch (Exception ex)
            {
                throw new Exception("error");
            }

        }

        public async Task<(IEnumerable<ViewSubmissionDTO>, int totalcount)> Getallsubmissionasync(int page = 1, int pagesize = 5, string searchterm = "")
        {
            try
            {
                var query = _context.Submissions.AsQueryable();

                if (!string.IsNullOrEmpty(searchterm))
                {
                    query = query.Where(c => c.feedback.Contains(searchterm) || c.filepaths.Contains(searchterm));
                    }

                var totalcount = query.Count();
                var result = await query.Skip((page - 1) * pagesize).Take(pagesize).Select(c => new ViewSubmissionDTO
                {
                    Submission_Id = c.Submission_Id,
                    Assignment_Id = c.Assignment_Id,
                    User_Id = c.User_Id,
                    feedback = c.feedback,
                    filepaths = c.filepaths,
                    grade = c.grade,
                    submission_date = c.submission_date

                }).ToListAsync();

                return (result, totalcount);
                
                }
            catch (Exception ex)
            {
                throw new Exception("error");
            }
        }
    }
}
