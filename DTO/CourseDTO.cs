using Learning_management_system.ENUM;
using Learning_management_system.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_management_system.DTO
{
    public class CreateCourseDTO
    {
        public string Course_Name { get; set; }

        public string Course_Description { get; set; }

        public int User_Id { get; set; }

        

       


    }
    public class UpdateCourseDTO: CreateCourseDTO
    {
        public int Course_Id { get; set; }

        


    }
    
    public class ViewCourseDTO
    {
        public string Course_Name { get; set; }

        public string Course_Description { get; set; }

        public DateTime Createddate { get; set; } 

        public DateTime Modifieddate { get; set; }

        public int Course_Id { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string email {  get; set; }

        public Usertype usertype  { get; set; }


        public int User_Id { get; set; }

        


    }

    public class ListCourseDTO
    {
        public int Course_Id { get; set; }

        public string Course_Name { get; set; }
    }
}
