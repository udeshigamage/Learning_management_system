using Learning_management_system.ENUM;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_management_system.Models
{
    [Table("Tb_Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int User_Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public Usertype User_Type { get; set; }

        public DateTime Createddate { get; set; }= DateTime.Now;


    }
}
