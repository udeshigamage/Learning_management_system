using Learning_management_system.ENUM;

namespace Learning_management_system.DTO
{
    //removed id because it is auto generated
    //removed password because it is not allowed to see user,secured
    public class ViewUserDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Usertype User_Type { get; set; }

        public DateTime Createddate { get; set; } = DateTime.Now;


    }

    public class CreateUserDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public Usertype User_Type { get; set; }

    }

    public class UpdateUserDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Usertype User_Type { get; set; }

    }
}
