using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_management_system.Models
{
    [Table("Tb_Forums")]
    public class Forums
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ForumTopic_Id { get; set; }

        public string ForumTopic { get; set; }

        public DateTime createddate { get; set; } = DateTime.UtcNow;
        [ForeignKey("User")]
        public int createdby { get; set; }
        [ForeignKey("Courses")]
        public int Course_Id { get; set; }

        public virtual Courses Courses { get; set; }

        public virtual User User { get; set; }

        public ICollection<Forumposts> forumposts { get; set; }




    }
}
