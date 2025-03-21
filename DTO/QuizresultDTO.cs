using Learning_management_system.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_management_system.DTO
{
    public class CreateQuizresultDTO
    {
        

        public decimal Score { get; set; }
   
       
        public int User_Id { get; set; }
       
        public int Quiz_Id { get; set; }

        
    }

    public class UpdateQuizresultDTO : CreateQuizresultDTO
    {
        public int result_Id { get; set; }

       
    }

    public class ViewQuizresultDTO
    {
        public int result_Id { get; set; }

        public decimal Score { get; set; }

        public DateTime datetaken { get; set; }
        
        public int User_Id { get; set; }
      
        public int Quiz_Id { get; set; }

       
    }

    
}
