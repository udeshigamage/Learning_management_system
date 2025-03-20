using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_management_system.Models
{
    [Table("Tb_Forumposts")]
    public class Forumposts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Forumpost_Id { get; set; }

        public string postcontent { get; set; }

        public DateTime Createddate { get; set; } = DateTime.UtcNow;
        [ForeignKey("Forums")]
        public int ForumTopic_Id { get; set; }

        public virtual Forums Forums { get; set; }

        [ForeignKey("User")]
        public int createdby { get; set; }

        public virtual User User { get; set; }
    }
}
