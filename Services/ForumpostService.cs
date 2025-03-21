using Learning_management_system.dbcontext;
using Learning_management_system.DTO;
using Learning_management_system.Interfaces;

namespace Learning_management_system.Services
{
    public class ForumpostService:IForumpostservice
    {
        private readonly Appdbcontext _context;
        public ForumpostService(Appdbcontext context)
        {
            _context = context;
        }
        public async Task<Message<string>> Createforumpostasync(CreateForumpost forumpost) {
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

        public async Task<Message<string>> Updateforumpostasync(UpdateForumpost forumpost, int id) {
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

        public async Task<Message<string>> Deleteforumpostasync(int id) {
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

        public async Task<IEnumerable<ViewForumpost>> Getviewforumpostasync(int id) {
            try
            {
            }
            catch (Exception ex)
            {
                throw new Exception("error");
            }
        }

        public async Task<(IEnumerable<ViewForumpost>, int totalcount)> Getallasync(int page = 1, int pagesize = 5, string searchterm = "", string filterBy = "", string filterValue = "") {
            try
            {
            }
            catch (Exception ex)
            {
                throw new Exception("error");
            }
        }

    }
}
