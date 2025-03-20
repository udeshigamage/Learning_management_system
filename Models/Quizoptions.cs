using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_management_system.Models
{
    [Table("Tb_Quizoptions")]
    public class Quizoptions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Option_Id { get; set; }

        public string Option_text { get; set; }

        public bool Is_correct { get; set; }
        [ForeignKey("Quizquestions")]
        public int Question_Id { get; set; }

        public virtual Quizquestions Quizquestions { get; set; }

    }
}
