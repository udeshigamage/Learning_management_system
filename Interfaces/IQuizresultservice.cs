using Learning_management_system.DTO;

namespace Learning_management_system.Interfaces
{
    public interface IQuizresultservice
    {
        Task<Message<string>> Createquizresultasync(CreateQuizresultDTO quizresult);

        Task<Message<string>> Updatequizresultasync(UpdateQuizresultDTO quizresult, int id);

        Task<Message<string>> Deletequizresultasync(int id);

        Task<IEnumerable<ViewQuizresultDTO>> Getviewquizresultasync(int id);

        Task<(IEnumerable<ViewQuizresultDTO>, int totalcount)> Getallquizresultasync(int page = 1, int pagesize = 5, string searchterm = "", string filterBy = "", string filterValue = "");

       
    }
}
