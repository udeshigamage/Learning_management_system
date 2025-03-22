using Learning_management_system.DTO;

namespace Learning_management_system.Interfaces
{
    public interface ICertification
    {
        Task<Message<string>> Createcertificationsasync(CreateCertificationsDTO certifications);

        Task<Message<string>> Updatecertificationsasync(UpdateCertificationsDTO certifications, int id);

        Task<Message<string>> Deletecertificationsasync(int id);

        Task<IEnumerable<ViewCertificationsDTO>> Getviewcertificationsasync(int id);

        Task<(IEnumerable<ViewCertificationsDTO>, int totalcount)> Getallcertificationsasync(int page = 1, int pagesize = 5, string searchterm = "");

       
    }
}
