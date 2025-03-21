using Learning_management_system.dbcontext;
using Learning_management_system.DTO;
using Learning_management_system.Interfaces;

namespace Learning_management_system.Services
{
    public class ForumService:IForumservice
    {
        private readonly Appdbcontext _context;
        public ForumService(Appdbcontext context)
        {
            _context = context;
        }
        public async Task<Message<string>> Createforumasync(CreateForumDTO forum) {
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

        public async Task<Message<string>> Updateforumasync(UpdateForumDTO forum, int id) {
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

        public async Task<Message<string>> Deleteforumasync(int id) {
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

        public async Task<IEnumerable<ViewForumDTO>> Getviewforumasync(int id) {
            try
            {
            }
            catch (Exception ex)
            {
                throw new Exception("error");
            }
        }

        public async Task<(IEnumerable<ViewForumDTO>, int totalcount)> Getallforumasync(int page = 1, int pagesize = 5, string searchterm = "", string filterBy = "", string filterValue = "") {
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
