using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_management_system.Models
{
    [Table("Tb_Liveclasses")]
    public class Liveclasses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Liveclass_Id { get; set; }

        public string vedio_link { get; set; }

        public string status { get; set; }

        public DateTime Createddate { get; set; } = DateTime.UtcNow;

        [ForeignKey("Courses")]

        public int Course_Id { get; set; }

        public virtual Courses Courses { get; set; }
        [ForeignKey("User")]
        public int instructor_id { get; set; }

        public virtual User User { get; set; }

        public ICollection<Courssemodules> courssemodules { get; set; }
    }
}
