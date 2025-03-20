using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_management_system.Models
{
    [Table("Tb_Announcement")]
    public class Announcement
    {
       
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Announcement_Id { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public DateTime Createddate { get; set; } = DateTime.UtcNow;

        [ForeignKey("Courses")]
        public int Course_Id { get; set; }

        public virtual Courses Courses { get; set; }
    }
}
