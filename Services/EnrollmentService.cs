using Learning_management_system.dbcontext;
using Learning_management_system.DTO;
using Learning_management_system.Interfaces;

namespace Learning_management_system.Services
{
    public class EnrollmentService:IEnrollmentservice
    {
        private readonly Appdbcontext _context;
        public EnrollmentService(Appdbcontext context)
        {
            _context = context;
        }
        public async Task<Message<string>> Createenrollmentasync(CreateEnrollmentDTO enrollment) {
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

        public async Task<Message<string>> Updateenrollmentasync(UpdateEnrollmentDTO enrollment, int id) {
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

        public async Task<Message<string>> Deleteenrollmentasync(int id) {
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

        public async Task<IEnumerable<ViewEnrollmentDTO>> Getviewenrollmentasync(int id) {
            try
            {
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<(IEnumerable<ViewEnrollmentDTO>, int totalcount)> Getallenrollmentasync(int page = 1, int pagesize = 5, string searchterm = "", string filterBy = "", string filterValue = "") {
            try
            {
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
