using Learning_management_system.dbcontext;
using Learning_management_system.DTO;
using Learning_management_system.Interfaces;

namespace Learning_management_system.Services
{
    public class QuizService:IQuizesservice
    {
        private readonly Appdbcontext _context;

        public QuizService(Appdbcontext context)
        {
            _context = context;
        }
        public async Task<Message<string>> Createquizasync(CreateQuizDTO quiz)
        {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<Message<string>> Updatequizasync(UpdateQuizDTO quiz, int id) {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<Message<string>> Deletequizasync(int id) {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<IEnumerable<ViewQuizDTO>> Getviewquizasync(int id) {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<(IEnumerable<ViewQuizDTO>, int totalcount)> Getallquizasync(int page = 1, int pagesize = 5, string searchterm = "", string filterBy = "", string filterValue = "")
        {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<IEnumerable<ListQuizDTO>> GetListquizasync()
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
