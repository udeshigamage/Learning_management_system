using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_management_system.Models
{
    [Table("Tb_Certifications")]
    public class Certifications
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Certification_Id { get; set; }

        public DateTime issue_date { get; set; } = DateTime.UtcNow;

        public DateTime expiry_date { get; set; } 

        public string certificate_code { get; set; }

        [ForeignKey("User")]
        public int User_Id { get; set; }

        [ForeignKey("Courses")]
        public int Course_Id { get; set; }

        public virtual User User { get; set; }

        public virtual Courses Courses { get; set; }


    }
}
