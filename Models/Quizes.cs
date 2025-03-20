using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_management_system.Models
{
    [Table("Tb_Quizes")]
    public class Quizes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Quiz_Id { get; set; }

        public string Quiz_Name { get; set; }

        public DateTime Createddate { get; set; } = DateTime.UtcNow;

        [ForeignKey("Courses")]
        public int Course_Id { get; set; }

        public virtual Courses Courses { get; set; }
    }
}
