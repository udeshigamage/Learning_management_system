using Learning_management_system.DTO;

namespace Learning_management_system.Interfaces
{
    public interface IAnnouncementservice
    {
        Task<Message<string>> Createannouncementasync(CreateAnnouncementDTO announcement);

        Task<Message<string>> Updateannouncementasync(UpdateAnnouncementDTO announcement, int id);

        Task<Message<string>> Deleteannouncementasync(int id);

        Task<IEnumerable<ViewAnnouncementDTO>> Getviewannouncementasync(int id);

        Task<(IEnumerable<ViewAnnouncementDTO>, int totalcount)> Getallannouncementasync(int page = 1, int pagesize = 5, string searchterm = "");

        
    }
}
