using Learning_management_system.dbcontext;
using Learning_management_system.DTO;
using Learning_management_system.Interfaces;

namespace Learning_management_system.Services
{
    public class QuizquestionService:IQuizquestions
    {
        private readonly Appdbcontext _context;
        public QuizquestionService(Appdbcontext context)
        {
            _context = context;
        }
        public async Task<Message<string>> Createquizquestionasync(CreateQuizquestionDTO quizquestion)
        {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<Message<string>> Updatequizquestionasync(UpdateQuizquestionDTO quizquestion, int id)
        {
            try
            {
            }
            catch (Exception ex)
            {
            }

        }

        public async Task<Message<string>> Deletequizquestionasync(int id) {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<IEnumerable<ViewQuizquestionDTO>> Getviewquizquestionasync(int id) {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<(IEnumerable<ViewQuizquestionDTO>, int totalcount)> Getallquizquestionasync(int page = 1, int pagesize = 5, string searchterm = "", string filterBy = "", string filterValue = "")
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
