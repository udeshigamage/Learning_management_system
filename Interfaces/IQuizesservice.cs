using Learning_management_system.DTO;

namespace Learning_management_system.Interfaces
{
    public interface IQuizesservice
    {
        Task<Message<string>> Createquizasync(CreateQuizDTO quiz);

        Task<Message<string>> Updatequizasync(UpdateQuizDTO quiz, int id);

        Task<Message<string>> Deletequizasync(int id);

        Task<IEnumerable<ViewQuizDTO>> Getviewquizasync(int id);

        Task<(IEnumerable<ViewQuizDTO>, int totalcount)> Getallquizasync(int page = 1, int pagesize = 5, string searchterm = "");

        Task<IEnumerable<ListQuizDTO>> GetListquizasync();
    }
}
