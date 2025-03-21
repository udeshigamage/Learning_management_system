using Learning_management_system.dbcontext;
using Learning_management_system.DTO;
using Learning_management_system.Interfaces;

namespace Learning_management_system.Services
{
    public class LiveclassService:ILiveclassService
    {
        private readonly Appdbcontext _context;
        public LiveclassService(Appdbcontext context)
        {
            _context = context;
        }
        public async Task<Message<string>> Createliveclassesasync(CreateLiveclassesDTO liveclasses) {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<Message<string>> Updateliveclassesasync(UpdateLiveclassesDTO liveclasses, int id) {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<Message<string>> Deleteliveclassesasync(int id) {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<IEnumerable<ViewLiveclassesDTO>> Getviewliveclassesasync(int id) {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<(IEnumerable<ViewLiveclassesDTO>, int totalcount)> Getallliveclassesasync(int page = 1, int pagesize = 5, string searchterm = "", string filterBy = "", string filterValue = "")
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
