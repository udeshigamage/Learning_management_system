using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_management_system.Models
{
    [Table("Tb_Assignment")]
    public class Assignment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Assignment_Id { get; set; }

        public string Assignment_Name { get; set; }

        public string Assignment_Description { get; set; }

        public DateTime Createddate { get; set; } = DateTime.UtcNow;

        public DateTime duedate { get; set; }

        [ForeignKey("Courssemodules")]
        public int Module_Id { get; set; }

        public virtual Courssemodules Courssemodules { get; set; }
    }
}
