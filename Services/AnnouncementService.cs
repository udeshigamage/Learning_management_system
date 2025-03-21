using Learning_management_system.dbcontext;
using Learning_management_system.DTO;
using Learning_management_system.Interfaces;
using Learning_management_system.Models;
using Microsoft.EntityFrameworkCore;

namespace Learning_management_system.Services
{
    public class AnnouncementService:IAnnouncementservice
    {
        private readonly Appdbcontext _context;

        public AnnouncementService(Appdbcontext context)
        {
            _context = context;
        }
       public async Task<Message<string>> Createannouncementasync(CreateAnnouncementDTO announcement)
        {
            try
            {
                var announcement_ = new Announcement
                {
                    title=announcement.title,
                    description=announcement.description,
                    Course_Id=announcement.Course_Id,
                    Createddate=DateTime.Now,

                };
                 _context.Announcement.Add(announcement_);
                await _context.SaveChangesAsync();
                return new Message<string>
                {
                    Status = "S",
                    Result = "Success"
                };


            }
            catch (Exception ex)
            {
                return new Message<string>
                {
                    Status="E",
                    Result=ex.Message
                };
            }

        }

        public async Task<Message<string>> Updateannouncementasync(UpdateAnnouncementDTO announcement, int id)
        {
            try
            {
                var existingannouncement = await _context.Announcement.FindAsync(id);
                if (existingannouncement == null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "Not found"
                    };
                }
                existingannouncement.title = announcement.title;
                existingannouncement.description= announcement.description;
                existingannouncement.Course_Id = announcement.Course_Id;

                _context.SaveChangesAsync();

                return new Message<string>
                {
                    Status = "S",
                    Result="Updated successfully"
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

        public async Task<Message<string>> Deleteannouncementasync(int id)
        {
            try
            {
                var announcement = await _context.Announcement.FindAsync(id);
                if(announcement == null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "Error"
                    };

                }
                _context.Announcement.Remove(announcement);
                _context.SaveChangesAsync();
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

        public async Task<IEnumerable<ViewAnnouncementDTO>> Getviewannouncementasync(int id)
        {
            try
            {
                var announcement = await _context.Announcement.Where(c => c.Announcement_Id == id).Select(c => new ViewAnnouncementDTO
                {
                    Course_Id= c.Course_Id,
                    Createddate= c.Createddate,
                    description= c.description,
                    title = c.title,
                    Announcement_Id = c.Announcement_Id,



                }).ToListAsync();

                return announcement;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<(IEnumerable<ViewAnnouncementDTO>, int totalcount)> Getallannouncementasync(int page = 1, int pagesize = 5, string searchterm = "")
        {
            try
            {
                var query =  _context.Announcement.AsQueryable();

                if(!string.IsNullOrEmpty(searchterm))
                {
                    query =  query.Where(c => c.title.Contains(searchterm) || c.description.Contains(searchterm));
                }

                var totalcount = query.Count();

                var announcement = await query.Skip((page - 1) * pagesize).Take(pagesize).Select(c => new ViewAnnouncementDTO
                {
                    Course_Id = c.Course_Id,
                    Createddate = c.Createddate,
                    description = c.description,
                    title = c.title,
                    Announcement_Id = c.Announcement_Id,


                }).ToListAsync();

                return(announcement,totalcount);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }



    }
}
