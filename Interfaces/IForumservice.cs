using Learning_management_system.DTO;

namespace Learning_management_system.Interfaces
{
    public interface IForumservice
    {
        Task<Message<string>> Createforumasync(CreateForumDTO forum);

        Task<Message<string>> Updateforumasync(UpdateForumDTO forum, int id);

        Task<Message<string>> Deleteforumasync(int id);

        Task<IEnumerable<ViewForumDTO>> Getviewforumasync(int id);

        Task<(IEnumerable<ViewForumDTO>, int totalcount)> Getallforumasync(int page = 1, int pagesize = 5, string searchterm = "");

       
    }
}
