using Learning_management_system.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_management_system.DTO
{
    public class CreateSubmissionDTO
    {
       

        

        public string feedback { get; set; }

        public string filepaths { get; set; }

        public string grade { get; set; }

        
        public int Assignment_Id { get; set; }

      
        public int User_Id { get; set; }

       
    }

    public class UpdateSubmissionDTO : CreateSubmissionDTO
    {
        public int Submission_Id { get; set; }

       
    }

    public class ViewSubmissionDTO
    {
        public int Submission_Id { get; set; }

        public DateTime submission_date { get; set; }

        public string feedback { get; set; }

        public string filepaths { get; set; }

        public string grade { get; set; }

        
        public int Assignment_Id { get; set; }

        
        public int User_Id { get; set; }

       
    }

   
}
