using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_management_system.Models
{
    [Table("Tb_Coursemodules")]
    public class Courssemodules
    {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]

        public int Module_Id { get; set; }

        public string Module_Name { get; set; }

        public string Module_Description { get; set; }

        [ForeignKey("Courses")]
        public int Course_Id { get; set; }

        public DateTime Createddate { get; set; } = DateTime.UtcNow;

        public virtual Courses Courses { get; set; }
    }
}
