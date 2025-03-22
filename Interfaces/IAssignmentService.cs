using Learning_management_system.DTO;

namespace Learning_management_system.Interfaces
{
    public interface IAssignmentService
    {
        Task<Message<string>> Createassignmentasync(CreateAssignmentDTO assignment);

        Task<Message<string>> Updateassignmentasync(UpdateAssignmentDTO assignment, int id);

        Task<Message<string>> Deleteassignmentasync(int id);

        Task<IEnumerable<ViewAssignmentDTO>> Getviewassignmentasync(int id);

        Task<(IEnumerable<ViewAssignmentDTO>, int totalcount)> Getallassignmentasync(int page = 1, int pagesize = 5, string searchterm = "");

        
    }
}
