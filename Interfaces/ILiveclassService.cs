using Learning_management_system.DTO;

namespace Learning_management_system.Interfaces
{
    public interface ILiveclassService
    {
        Task<Message<string>> Createliveclassesasync(CreateLiveclassesDTO liveclasses);

        Task<Message<string>> Updateliveclassesasync(UpdateLiveclassesDTO liveclasses, int id);

        Task<Message<string>> Deleteliveclassesasync(int id);

        Task<IEnumerable<ViewLiveclassesDTO>> Getviewliveclassesasync(int id);

        Task<(IEnumerable<ViewLiveclassesDTO>, int totalcount)> Getallliveclassesasync(int page = 1, int pagesize = 5, string searchterm = "", string filterBy = "", string filterValue = "");

        
    }
}
