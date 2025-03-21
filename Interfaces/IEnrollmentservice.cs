using Learning_management_system.DTO;

namespace Learning_management_system.Interfaces
{
    public interface IEnrollmentservice
    {
        Task<Message<string>> Createenrollmentasync(CreateEnrollmentDTO enrollment);

        Task<Message<string>> Updateenrollmentasync(UpdateEnrollmentDTO enrollment, int id);

        Task<Message<string>> Deleteenrollmentasync(int id);

        Task<IEnumerable<ViewEnrollmentDTO>> Getviewenrollmentasync(int id);

        Task<(IEnumerable<ViewEnrollmentDTO>, int totalcount)> Getallenrollmentasync(int page = 1, int pagesize = 5, string searchterm = "", string filterBy = "", string filterValue = "");

        
    }
}
