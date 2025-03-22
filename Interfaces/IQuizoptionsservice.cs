using Learning_management_system.DTO;

namespace Learning_management_system.Interfaces
{
    public interface IQuizoptionsservice
    {
        Task<Message<string>> Createquizoptionasync(CreateQuizoptionDTO quizoption);

        Task<Message<string>> Updatequizoptionasync(UpdateQuizoptionDTO quizoption, int id);

        Task<Message<string>> Deletequizoptionasync(int id);

        Task<IEnumerable<ViewQuizoptionDTO>> Getviewquizoptionasync(int id);

        Task<(IEnumerable<ViewQuizoptionDTO>, int totalcount)> Getallquizoptionasync(int page = 1, int pagesize = 5, string searchterm = "");

        Task<IEnumerable<ListQuizoptionDTO>> GetListquizoptionasync();
    }
}
