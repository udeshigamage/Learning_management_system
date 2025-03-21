using Learning_management_system.ENUM;
using Learning_management_system.Models;

namespace Learning_management_system.DTO
{
    
    public class CreateEnrollmentDTO
    {
       

        
        public Enrollmentstatus enrollmentstatus { get; set; }

        public int User_Id { get; set; }

        public int Course_Id { get; set; }

       
    }

    public class UpdateEnrollmentDTO : CreateEnrollmentDTO
    {
        public int Enrollment_Id { get; set; }

      
    }

    public class ViewEnrollmentDTO
    {
        public int Enrollment_Id { get; set; }

        public DateTime Enrollment_date { get; set; } 

        public Enrollmentstatus enrollmentstatus { get; set; }

        public int User_Id { get; set; }

        public int Course_Id { get; set; }

       
    }

    
}
