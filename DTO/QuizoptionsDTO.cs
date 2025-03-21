using Learning_management_system.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_management_system.DTO
{
    public class CreateQuizoptionDTO
    {
       

        public string Option_text { get; set; }

        public bool Is_correct { get; set; }
       
        public int Question_Id { get; set; }

        
    }

    public class UpdateQuizoptionDTO : CreateQuizoptionDTO
    {
        public int Option_Id { get; set; }

       
    }

    public class ViewQuizoptionDTO
    {
        public int Option_Id { get; set; }

        public string Option_text { get; set; }

        public bool Is_correct { get; set; }
        
        public int Question_Id { get; set; }

        
    }

    public class ListQuizoptionDTO
    {
        public int Option_Id { get; set; }

        public string Option_text { get; set; }

        
    }
}
