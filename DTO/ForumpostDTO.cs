using Learning_management_system.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_management_system.DTO
{
    public class CreateForumpost
    {
       

        public string postcontent { get; set; }

        
        public int ForumTopic_Id { get; set; }

        
        public int createdby { get; set; }

       
    }

    public class UpdateForumpost : CreateForumpost
    {
        public int Forumpost_Id { get; set; }

        
    }

    public class ViewForumpost
    {
        public int Forumpost_Id { get; set; }

        public string postcontent { get; set; }

        public DateTime Createddate { get; set; } 
       
        public int ForumTopic_Id { get; set; }

      

        
        public int createdby { get; set; }

       
    }

    
}
