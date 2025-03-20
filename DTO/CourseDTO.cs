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

        public DateTime Modifieddate { get; set; }


    }
    
    public class ViewCourseDTO
    {
        public string Course_Name { get; set; }

        public string Course_Description { get; set; }

        public DateTime Createddate { get; set; } = DateTime.UtcNow;

        public DateTime Modifieddate { get; set; }

       

        public int User_Id { get; set; }

        


    }
}
