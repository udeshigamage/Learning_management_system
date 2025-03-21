using Learning_management_system.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_management_system.DTO
{
    public class createCoursemoduleDTO
    {
       

        public string Module_Name { get; set; }

        public string Module_Description { get; set; }

        
        public int Course_Id { get; set; }

        

        
    }
    public class viewCoursemoduleDTO
    {
        public int Module_Id { get; set; }

        public string Module_Name { get; set; }

        public string Module_Description { get; set; }

       
        public int Course_Id { get; set; }

        public DateTime Createddate { get; set; }

        public DateTime Modifieddate { get; set; }

        public string Course_Name { get; set; }

    }
    public class updateCoursemoduleDTO:createCoursemoduleDTO
    {
        public int Module_Id { get; set; }

        public DateTime Modifieddate { get; set; }= DateTime.Now;


    }

    public class listCoursemoduleDTO
    {
        public int Module_Id { get; set; }

        public string Module_Name { get; set; }

        
    }


    

}
