using Learning_management_system.DTO;

namespace Learning_management_system.Interfaces
{
    public interface ICoursemoduleService
    {
        Task<Message<string>> CreatecoursemoduleAsync(createCoursemoduleDTO coursemoduleDTO);

        Task<Message<string>> Updatecoursemodule(updateCoursemoduleDTO coursemoduleDTO,int id);

        Task<Message<string>> deletecoursemodule(int id);

        Task<(IEnumerable<viewCoursemoduleDTO>, int totalcount)> getallcoursemodules(int page = 1, int pagesize = 5,string searchterm ="");

        Task<IEnumerable<viewCoursemoduleDTO>> getcoursemodulebyid(int id);

        Task<IEnumerable<listCoursemoduleDTO>> listcoursemodule();

    }
}
