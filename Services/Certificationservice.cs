using Learning_management_system.dbcontext;
using Learning_management_system.DTO;
using Learning_management_system.Interfaces;

namespace Learning_management_system.Services
{
    public class Certificationservice : ICertification
    {
        private readonly Appdbcontext _context;
        public Certificationservice(Appdbcontext context)
        {
            _context = context;
        }

      public async  Task<Message<string>> CreatecoursemoduleAsync(createCoursemoduleDTO coursemoduleDTO)
        {

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

        public async Task<Message<string>> Updatecoursemodule(updateCoursemoduleDTO coursemoduleDTO, int id) {
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

       public async Task<Message<string>> deletecoursemodule(int id) {
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

        public async Task<(IEnumerable<viewCoursemoduleDTO>, int totalcount)> getallcoursemodules(int page = 1, int pagesize = 5, string searchterm = "") {
            try
            {
            }
            catch (Exception ex)
            {
                throw new Exception("Error");
            }
        }

        public async Task<IEnumerable<viewCoursemoduleDTO>> getcoursemodulebyid(int id) {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<IEnumerable<listCoursemoduleDTO>> listcoursemodule() {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }


    }
}
