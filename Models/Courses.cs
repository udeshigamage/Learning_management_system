using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_management_system.Models

    
{
    [Table("Tb_Courses")]
    public class Courses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Course_Id { get; set; }

        public string Course_Name { get; set; }

        public string Course_Description { get; set; }

        public DateTime Createddate { get; set; } = DateTime.UtcNow;

        public DateTime Modifieddate { get; set; }

        [ForeignKey("user")]

        public int User_Id { get; set; }

        public virtual User user{ get; set; }

        public ICollection<Courssemodules> courssemodules { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }

        public ICollection<Announcement> Announcements { get; set; }

        public ICollection<Assignment> Assignment { get; set; }

        public ICollection<Quizes> Quizes { get; set; }


    }
}
