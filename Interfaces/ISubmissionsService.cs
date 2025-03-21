using Learning_management_system.DTO;

namespace Learning_management_system.Interfaces
{
    public interface ISubmissionsService
    {
        Task<Message<string>> Createsubmissionasync(CreateSubmissionDTO submission);

        Task<Message<string>> Updatesubmissionasync(UpdateSubmissionDTO submission, int id);

        Task<Message<string>> Deletesubmissionasync(int id);

        Task<IEnumerable<ViewSubmissionDTO>> Getviewsubmissionasync(int id);

        Task<(IEnumerable<ViewSubmissionDTO>, int totalcount)> Getallsubmissionasync(int page = 1, int pagesize = 5, string searchterm = "", string filterBy = "", string filterValue = "");

        
    }
}
