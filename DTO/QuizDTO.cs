using Learning_management_system.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_management_system.DTO
{
    public class CreateQuizDTO
    {
        

        public string Quiz_Name { get; set; }

        
        
        public int Course_Id { get; set; }

       
    }

    public class UpdateQuizDTO : CreateQuizDTO
    {
        public int Quiz_Id { get; set; }

       
    }

    public class ViewQuizDTO
    {
        public int Quiz_Id { get; set; }

        public string Quiz_Name { get; set; }

        public DateTime Createddate { get; set; } 

        
        public int Course_Id { get; set; }

       
    }

    public class ListQuizDTO
    {
        public int Quiz_Id { get; set; }

        public string Quiz_Name { get; set; }

       
    }
}
