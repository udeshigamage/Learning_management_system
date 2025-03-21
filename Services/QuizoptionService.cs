using Learning_management_system.dbcontext;
using Learning_management_system.DTO;
using Learning_management_system.Interfaces;

namespace Learning_management_system.Services
{
    public class QuizoptionService:IQuizoptionsservice
    {
        private readonly Appdbcontext _context;

        public QuizoptionService(Appdbcontext context)
        {
            _context = context;
        }
        public async Task<Message<string>> Createquizoptionasync(CreateQuizoptionDTO quizoption) {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<Message<string>> Updatequizoptionasync(UpdateQuizoptionDTO quizoption, int id) {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<Message<string>> Deletequizoptionasync(int id) {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<IEnumerable<ViewQuizoptionDTO>> Getviewquizoptionasync(int id) {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<(IEnumerable<ViewQuizoptionDTO>, int totalcount)> Getallquizoptionasync(int page = 1, int pagesize = 5, string searchterm = "", string filterBy = "", string filterValue = "") {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<IEnumerable<ListQuizoptionDTO>> GetListquizoptionasync()
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
