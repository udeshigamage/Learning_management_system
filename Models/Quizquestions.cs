using Learning_management_system.ENUM;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_management_system.Models
{
    [Table("Tb_Quizquestions")]
    public class Quizquestions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int question_Id { get; set; }

        public Answertypes answertypes { get; set; }

        public string question_text { get; set; }
        [ForeignKey("Quizes")]
        public int Quiz_Id { get; set; }

        public virtual Quizes Quizes { get; set; }

        public ICollection<Quizoptions> Quizoptions { get; set; }

    }
}
