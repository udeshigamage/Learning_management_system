using Learning_management_system.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_management_system.DTO
{
    public class CreateAnnouncementDTO
    {
       

        public string title { get; set; }

        public string description { get; set; }

        

        
        public int Course_Id { get; set; }

       
    }
    public class UpdateAnnouncementDTO:CreateAnnouncementDTO
    {
        public int Announcement_Id { get; set; }


        
    }
    public class ViewAnnouncementDTO
    {
        public int Announcement_Id { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public DateTime Createddate { get; set; } 

       
        public int Course_Id { get; set; }

        public string Coursename { get; set; }
    }
    public class AnnouncementListDTO
    {
        public int Announcement_Id { get; set; }

        public string title { get; set; }

    }
}
