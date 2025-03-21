using Learning_management_system.dbcontext;
using Learning_management_system.DTO;
using Learning_management_system.Interfaces;
using Learning_management_system.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Learning_management_system.Services
{
    public class AssignmentService:IAssignmentService
    {
        private readonly Appdbcontext _context;
        public AssignmentService(Appdbcontext context)
        {
            _context = context;
        }

        public async Task<Message<string>> Createassignmentasync(CreateAssignmentDTO assignment)
        {
            try
            {
                var assignment_ = new Assignment
                {
                    Assignment_Name=assignment.Assignment_Name,
                    Assignment_Description=assignment.Assignment_Description,
                    Createddate=DateTime.Now,
                    duedate=assignment.duedate,
                    Module_Id=assignment.Module_Id,
                   

                };

                _context.Assignment.Add(assignment_);
                await _context.SaveChangesAsync();
                return new Message<string>
                {
                    Status = "S",
                    Result = "Successfully created ASSignment"
                };


            }
            catch (Exception ex)
            {
                return new Message<string>
                {
                    Status="E",
                    Result=ex.Message
                };
            }

        }

        public async Task<Message<string>> Updateassignmentasync(UpdateAssignmentDTO assignment, int id) {
            try
            {
                var existingassignment_ = await _context.Assignment.FindAsync(id);
                if (existingassignment_ == null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "Not found"
                    };
                }
                existingassignment_.Assignment_Name = assignment.Assignment_Name;
                existingassignment_.Assignment_Description= assignment.Assignment_Description;
                existingassignment_.duedate = assignment.duedate;
                existingassignment_.Module_Id=assignment.Module_Id;

                await _context.SaveChangesAsync();
                return new Message<string>
                {
                    Status = "S",
                    Result = "Updated successfully"
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

        public async Task<Message<string>> Deleteassignmentasync(int id) {
            try
            {
                var assignment = await _context.Assignment.FindAsync(id);
                if(assignment == null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "Error"
                    };
                }
                _context.Assignment.Remove(assignment);
                await _context.SaveChangesAsync();
                return new Message<string>
                {
                    Status = "S",
                    Result ="Successfully deleted"
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

        public async  Task<IEnumerable<ViewAssignmentDTO>> Getviewassignmentasync(int id) {
            try
            {
                var assignment = await _context.Assignment.Where(c => c.Assignment_Id == id).Select(c => new ViewAssignmentDTO
                {
                    Module_Id = c.Module_Id,
                    duedate = c.duedate,
                    Createddate = c.Createddate,
                    Assignment_Description = c.Assignment_Description,
                    Assignment_Name= c.Assignment_Name,
                    Assignment_Id = c.Assignment_Id

                }).ToListAsync();
                return assignment;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<(IEnumerable<ViewAssignmentDTO>, int totalcount)> Getallassignmentasync(int page = 1, int pagesize = 5, string searchterm = "", string filterBy = "", string filterValue = "")
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
