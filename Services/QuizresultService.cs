using Learning_management_system.dbcontext;
using Learning_management_system.DTO;
using Learning_management_system.Interfaces;

namespace Learning_management_system.Services
{
    public class QuizresultService:IQuizresultservice
    {
        private readonly Appdbcontext _context;
        public QuizresultService(Appdbcontext context)
        {
            _context = context;
        }
        public async Task<Message<string>> Createquizresultasync(CreateQuizresultDTO quizresult)
        {
            try
            {
            }
            catch (Exception ex)
            {
            }

        }

        public async Task<Message<string>> Updatequizresultasync(UpdateQuizresultDTO quizresult, int id)
        {
            try
            {
            }
            catch (Exception ex)
            {
            }

        }

        public async Task<Message<string>> Deletequizresultasync(int id)
        {
            try
            {
            }
            catch (Exception ex)
            {
            }

        }

        public async Task<IEnumerable<ViewQuizresultDTO>> Getviewquizresultasync(int id)
        {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<(IEnumerable<ViewQuizresultDTO>, int totalcount)> Getallquizresultasync(int page = 1, int pagesize = 5, string searchterm = "", string filterBy = "", string filterValue = "")
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
