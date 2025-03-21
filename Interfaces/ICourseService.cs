using Learning_management_system.DTO;

namespace Learning_management_system.Interfaces
{
    public interface ICourseService
    {
        Task <Message<string>> Createcourseasync(CreateCourseDTO course);

        Task <Message<string>> Updatecourseasync(UpdateCourseDTO course, int id);

        Task <Message<string>> Deletecourseasync(int id);

        Task <IEnumerable<ViewCourseDTO>> Getviewcourseasync(int id);

        Task<(IEnumerable<ViewCourseDTO>, int totalcount)> Getallasync(int page = 1, int pagesize = 5, string searchterm = "", string filterBy = "", string filterValue = "");

        Task<IEnumerable<ListCourseDTO>> GetListcourseasync();

        
    }
}
