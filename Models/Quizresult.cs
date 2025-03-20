using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_management_system.Models
{
    [Table("Tb_Quizresult")]
    public class Quizresult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int result_Id { get; set; }

        public decimal Score { get; set; }

        public DateTime datetaken { get; set; }
        [ForeignKey("User")]
        public int User_Id { get; set; }
        [ForeignKey("Quizes")]
        public int Quiz_Id { get; set; }

        public virtual User User { get; set; }

        public virtual Quizes Quizes { get; set; }
    }
}
