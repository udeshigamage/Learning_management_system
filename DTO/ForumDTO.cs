using Learning_management_system.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_management_system.DTO
{
    public class CreateForumDTO
    {
       

        public string ForumTopic { get; set; }

        
        public int createdby { get; set; }
       
        public int Course_Id { get; set; }

       
    }

    public class UpdateForumDTO : CreateForumDTO
    {
        public int ForumTopic_Id { get; set; }

        
    }

    public class ViewForumDTO
    {
        public int ForumTopic_Id { get; set; }

        public string ForumTopic { get; set; }

        public DateTime createddate { get; set; } 
        public int createdby { get; set; }
       
        public int Course_Id { get; set; }

       
    }

  
}
