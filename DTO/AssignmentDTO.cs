using Learning_management_system.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_management_system.DTO
{
    public class CreateAssignmentDTO
    {
       

        public string Assignment_Name { get; set; }

        public string Assignment_Description { get; set; }

       

        public DateTime duedate { get; set; }

       
        public int Module_Id { get; set; }

       

    }
    public class UpdateAssignmentDTO:CreateAssignmentDTO
    {
        public int Assignment_Id { get; set; }
    }
    public class ViewAssignmentDTO
    {
        public int Assignment_Id { get; set; }

        public string Assignment_Name { get; set; }

        public string Assignment_Description { get; set; }

        public DateTime Createddate { get; set; } 

        public DateTime duedate { get; set; }

      
        public int Module_Id { get; set; }

        

    }
    public class AssignmentListDTO
    {
        public int Assignment_Id { get; set; }

        public string Assignment_Name { get; set; }

       
    }
}
