using Learning_management_system.ENUM;
using Learning_management_system.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_management_system.DTO
{
    public class CreateQuizquestionDTO
    {
      

        public Answertypes answertypes { get; set; }

        public string question_text { get; set; }
       
        public int Quiz_Id { get; set; }

        
    }

    public class UpdateQuizquestionDTO : CreateQuizquestionDTO
    {
        public int question_Id { get; set; }

        
    }

    public class ViewQuizquestionDTO
    {
        public int question_Id { get; set; }

        public Answertypes answertypes { get; set; }

        public string question_text { get; set; }
        
        public int Quiz_Id { get; set; }

        
    }

   
}
