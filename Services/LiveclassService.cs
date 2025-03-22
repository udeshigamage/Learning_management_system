using Learning_management_system.dbcontext;
using Learning_management_system.DTO;
using Learning_management_system.Interfaces;
using Learning_management_system.Models;
using Microsoft.EntityFrameworkCore;

namespace Learning_management_system.Services
{
    public class LiveclassService:ILiveclassService
    {
        private readonly Appdbcontext _context;
        public LiveclassService(Appdbcontext context)
        {
            _context = context;
        }
        public async Task<Message<string>> Createliveclassesasync(CreateLiveclassesDTO liveclasses) {
            try
            {
                var liveclass = new Liveclasses
                {
                    instructor_id = liveclasses.instructor_id,
                    Course_Id = liveclasses.Course_Id,
                    status = liveclasses.status,
                    vedio_link=liveclasses.vedio_link


                };
                _context.Liveclasses.Add(liveclass);
                await _context.SaveChangesAsync();
                return new Message<string>
                {
                    Status="S",
                    Result="successfully entered"

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

        public async Task<Message<string>> Updateliveclassesasync(UpdateLiveclassesDTO liveclasses, int id) {
            try
            {
                var existingliveclass = await _context.Liveclasses.FindAsync(id);

                if(existingliveclass == null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "Error"
                    };

                }

                existingliveclass.vedio_link = liveclasses.vedio_link;
                existingliveclass.instructor_id = liveclasses.instructor_id;
                existingliveclass.Course_Id = liveclasses.Course_Id;
                existingliveclass.status = liveclasses.status;

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

        public async Task<Message<string>> Deleteliveclassesasync(int id) {
            try
            {
                var liveclass = await _context.Liveclasses.FindAsync(id);
                if(liveclass == null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "Error"
                    };
                }
                _context.Liveclasses.Remove(liveclass);
                await _context.SaveChangesAsync();
                return new Message<string>
                {
                    Status = "S",
                    Result = "Successfully deleted"
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

        public async Task<IEnumerable<ViewLiveclassesDTO>> Getviewliveclassesasync(int id) {
            try
            {
                var liveclass = await _context.Liveclasses.Where(c => c.Liveclass_Id == id).Select(c => new ViewLiveclassesDTO
                {
                    instructor_id= c.instructor_id,
                    Course_Id= c.Course_Id,
                    Createddate =c.Createddate,
                    status = c.status,
                    Liveclass_Id = c.Liveclass_Id,
                    vedio_link = c.vedio_link,



                }).ToListAsync();
                return liveclass;
            }
            catch (Exception ex)
            {
                throw new Exception("error");

            }
        }

        public async Task<(IEnumerable<ViewLiveclassesDTO>, int totalcount)> Getallliveclassesasync(int page = 1, int pagesize = 5, string searchterm = "")
        {
            try
            {
                var query = _context.Liveclasses.AsQueryable();
                if (!string.IsNullOrEmpty(searchterm))
                {
                    query = query.Where(c => c.Courses.Course_Name.Contains(searchterm) || c.User.FirstName.Contains(searchterm) || c.status.Contains(searchterm) || c.vedio_link.Contains(searchterm));
                }
                var totalcount = query.Count();
                var liveclass = await query.Skip((page - 1) * pagesize).Take(pagesize).Select(c => new ViewLiveclassesDTO
                {
                    instructor_id = c.instructor_id,
                    Course_Id = c.Course_Id,
                    Createddate = c.Createddate,
                    status = c.status,
                    Liveclass_Id = c.Liveclass_Id
                }).ToListAsync();

                return (liveclass, totalcount);
            }
            catch (Exception ex)
            {
                throw new Exception("error");
            }
        }

    }
}
