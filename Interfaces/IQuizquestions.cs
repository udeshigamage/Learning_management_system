using Learning_management_system.DTO;

namespace Learning_management_system.Interfaces
{
    public interface IQuizquestions
    {
        Task<Message<string>> Createquizquestionasync(CreateQuizquestionDTO quizquestion);

        Task<Message<string>> Updatequizquestionasync(UpdateQuizquestionDTO quizquestion, int id);

        Task<Message<string>> Deletequizquestionasync(int id);

        Task<IEnumerable<ViewQuizquestionDTO>> Getviewquizquestionasync(int id);

        Task<(IEnumerable<ViewQuizquestionDTO>, int totalcount)> Getallquizquestionasync(int page = 1, int pagesize = 5, string searchterm = "", string filterBy = "", string filterValue = "");

        
    }
}
