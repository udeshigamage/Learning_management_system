using Learning_management_system.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_management_system.DTO
{
    public class  CreateCertificationsDTO
    {
       

        
        public DateTime expiry_date { get; set; }

        public string certificate_code { get; set; }

       
        public int User_Id { get; set; }

       
        public int Course_Id { get; set; }

       
    }

    public class UpdateCertificationsDTO:CreateCertificationsDTO
    {
        public int Certification_Id { get; set; }
    }

    public class ViewCertificationsDTO
    {
        public int Certification_Id { get; set; }

        public DateTime issue_date { get; set; }

        public DateTime expiry_date { get; set; }

        public string certificate_code { get; set; }

       
        public int User_Id { get; set; }

       
        public int Course_Id { get; set; }

       
    }

    

    
}
