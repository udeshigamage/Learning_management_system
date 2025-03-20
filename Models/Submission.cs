using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_management_system.Models
{
    [Table("Tb_Submission")]
    public class Submission
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Submission_Id { get; set; }

        public DateTime submission_date { get; set; } = DateTime.UtcNow;

        public string feedback { get; set; }

        public string filepaths { get; set; }

        public string grade { get; set; }

        [ForeignKey("Assignment")]
        public int Assignment_Id { get; set; }

        [ForeignKey("User")]
        public int User_Id { get; set; }

        public virtual Assignment Assignment { get; set; }

        public virtual User User { get; set; }
    }
}
