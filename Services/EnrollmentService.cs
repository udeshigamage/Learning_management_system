using Learning_management_system.dbcontext;
using Learning_management_system.DTO;
using Learning_management_system.ENUM;
using Learning_management_system.Interfaces;
using Learning_management_system.Models;
using Microsoft.EntityFrameworkCore;

namespace Learning_management_system.Services
{
    public class EnrollmentService:IEnrollmentservice
    {
        private readonly Appdbcontext _context;
        public EnrollmentService(Appdbcontext context)
        {
            _context = context;
        }
        public async Task<Message<string>> Createenrollmentasync(CreateEnrollmentDTO enrollment) {
            try
            {
                var newenrollment = new Enrollment
                {
                    Enrollment_date = DateTime.UtcNow,
                    Course_Id   = enrollment.Course_Id,
                    enrollmentstatus =enrollment.enrollmentstatus,
                    User_Id =enrollment.User_Id




                };
                _context.Enrollments.Add(newenrollment);
                await _context.SaveChangesAsync();
                return new Message<string>
                {
                    Status= "S",
                    Text ="succes"

                };


            }
            catch (Exception ex)
            {
                return new Message<string>
                {
                    Status = "E",
                    Result = ex.Message
                };
            }
        }

        public async Task<Message<string>> Updateenrollmentasync(UpdateEnrollmentDTO enrollment, int id) {
            try
            {
                var existingenrollment = await _context.Enrollments.FindAsync(id);

                if (existingenrollment == null)
                {


                    return new Message<string>
                    {
                        Status = "E",
                        Result = "Error"
                    };

                }
                existingenrollment.enrollmentstatus= enrollment.enrollmentstatus; ;
                existingenrollment.Course_Id= enrollment.Course_Id;
                existingenrollment.User_Id= enrollment.User_Id;

                _context.SaveChangesAsync();


                return new Message<string>
                {
                    Status = "S",
                    Result = "Successfully updated"
                };
            }
            catch (Exception ex)
            {
                return new Message<string>
                {
                    Status = "E",
                    Result = ex.Message
                };
            }
        }

        public async Task<Message<string>> Deleteenrollmentasync(int id) {
            try
            {
                var enrollment = await _context.Enrollments.FindAsync(id);

                if(enrollment == null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "Error"
                    };
                }
                _context.Enrollments.Remove(enrollment);
                _context.SaveChangesAsync();
                return new Message<string>
                {
                    Status = "S",
                    Result = "successfully deleted"
                };

            }
            catch (Exception ex)
            {
                return new Message<string>
                {
                    Status = "E",
                    Result = ex.Message
                };
            }
        }

        public async Task<IEnumerable<ViewEnrollmentDTO>> Getviewenrollmentasync(int id) {
            try
            {
                var enrollment = await _context.Enrollments.Where(c => c.Enrollment_Id == id).Select(c => new ViewEnrollmentDTO
                {
                    Course_Id = c.Course_Id,
                    User_Id = c.User_Id,
                    enrollmentstatus = c.enrollmentstatus,
                    Enrollment_date = c.Enrollment_date,
                    Enrollment_Id = c.Enrollment_Id


                }).ToListAsync();
                return enrollment;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<(IEnumerable<ViewEnrollmentDTO>, int totalcount)> Getallenrollmentasync(int page = 1, int pagesize = 5, string searchterm = "", string filterBy = "", string filterValue = "") {
            try
            {
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
