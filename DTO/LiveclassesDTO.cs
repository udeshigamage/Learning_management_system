using Learning_management_system.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_management_system.DTO
{
    public class CreateLiveclassesDTO
    {


        public string vedio_link { get; set; }

        public string status { get; set; }



        public int Course_Id { get; set; }


        public int instructor_id { get; set; }


    }

    public class UpdateLiveclassesDTO : CreateLiveclassesDTO
    {
        public int Liveclass_Id { get; set; }


    }

    public class ViewLiveclassesDTO
    {
        public int Liveclass_Id { get; set; }

        public string vedio_link { get; set; }

        public string status { get; set; }

        public DateTime Createddate { get; set; }



        public int Course_Id { get; set; }


        public int instructor_id { get; set; }


    }

}
