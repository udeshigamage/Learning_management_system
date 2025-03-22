using Learning_management_system.DTO;

namespace Learning_management_system.Interfaces
{
    public interface IForumpostservice
    {
        Task<Message<string>> Createforumpostasync(CreateForumpost forumpost);

        Task<Message<string>> Updateforumpostasync(UpdateForumpost forumpost, int id);

        Task<Message<string>> Deleteforumpostasync(int id);

        Task<IEnumerable<ViewForumpost>> Getviewforumpostasync(int id);

        Task<(IEnumerable<ViewForumpost>, int totalcount)> Getallasync(int page = 1, int pagesize = 5, string searchterm = "");

       
    }
}
