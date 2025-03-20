using Learning_management_system.DTO;

namespace Learning_management_system.Interfaces
{
    public interface IUserService
    {
        Task<Message<string>> Createuserasync(CreateUserDTO user);

        Task<Message<string>> Updateuserasync(UpdateUserDTO user, int id);

        Task<Message<string>> Deleteuserasync(int id);

        Task<IEnumerable<ViewUserDTO>> Getviewuserasync(int id);

        Task<(IEnumerable<ViewUserDTO>, int Totalpages)> GetAllviewusersasync(int page = 1, int pagesize = 5);
    }
}