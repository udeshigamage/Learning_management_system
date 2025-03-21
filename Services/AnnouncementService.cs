using Learning_management_system.dbcontext;
using Learning_management_system.DTO;
using Learning_management_system.Interfaces;
using Learning_management_system.Models;

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

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<(IEnumerable<ViewAnnouncementDTO>, int totalcount)> Getallannouncementasync(int page = 1, int pagesize = 5, string searchterm = "", string filterBy = "", string filterValue = "")
        {
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
