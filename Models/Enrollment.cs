using Learning_management_system.ENUM;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_management_system.Models
{
    [Table("Tb_Enrollment")]
    public class Enrollment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Enrollment_Id { get; set; }

        public DateTime Enrollment_date { get; set; } = DateTime.UtcNow;

        public Enrollmentstatus enrollmentstatus { get; set; }

        public int User_Id { get; set; }

        public int Course_Id { get; set; }

        public virtual User User { get; set; }

        public virtual Courses Courses { get; set; }
    }
}
