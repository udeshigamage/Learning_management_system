using Learning_management_system.dbcontext;
using Learning_management_system.DTO;
using Learning_management_system.Interfaces;
using Learning_management_system.Models;

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
