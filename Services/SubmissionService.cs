using Learning_management_system.dbcontext;
using Learning_management_system.DTO;
using Learning_management_system.Interfaces;

namespace Learning_management_system.Services
{
    public class SubmissionService:ISubmissionsService
    {
        private readonly Appdbcontext _context;

        public SubmissionService(Appdbcontext context)
        {
            _context = context;
        }
        public async Task<Message<string>> Createsubmissionasync(CreateSubmissionDTO submission)
        {
            try
            {
            }
            catch (Exception ex)
            {

            }

        }

        public async Task<Message<string>> Updatesubmissionasync(UpdateSubmissionDTO submission, int id)
        {
            try
            {
            }
            catch (Exception ex)
            {
            }

        }

        public async Task<Message<string>> Deletesubmissionasync(int id)
        {
            try
            {
            }
            catch (Exception ex)
            {
            }

        }

        public async Task<IEnumerable<ViewSubmissionDTO>> Getviewsubmissionasync(int id)
        {
            try
            {
            }
            catch (Exception ex)
            {
            }

        }

        public async Task<(IEnumerable<ViewSubmissionDTO>, int totalcount)> Getallsubmissionasync(int page = 1, int pagesize = 5, string searchterm = "", string filterBy = "", string filterValue = "")
        {
            try
            {
            }
            catch (Exception ex)
            {

            }
        }
    }
}
