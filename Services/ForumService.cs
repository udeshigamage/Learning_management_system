using Learning_management_system.dbcontext;
using Learning_management_system.DTO;
using Learning_management_system.Interfaces;
using Learning_management_system.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Learning_management_system.Services
{
    public class ForumService:IForumservice
    {
        private readonly Appdbcontext _context;
        public ForumService(Appdbcontext context)
        {
            _context = context;
        }
        public async Task<Message<string>> Createforumasync(CreateForumDTO forum) {
            try
            {
                var forum_ = new Forums
                {
                        ForumTopic = forum.ForumTopic,
                       createdby =forum.createdby,
                    Course_Id =forum.createdby

                };
                _context.Forums.Add(forum_);
                await _context.SaveChangesAsync();
                return new Message<string>
                {
                     Status="S",
                     Result ="Successfully created forum"

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

        public async Task<Message<string>> Updateforumasync(UpdateForumDTO forum, int id) {
            try
            {
                var existingforum = await _context.Forums.FindAsync(id);

                if (existingforum == null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "Error"
                    };

                }
                existingforum.ForumTopic = forum.ForumTopic;
                existingforum.ForumTopic_Id = forum.ForumTopic_Id;
                existingforum.createdby = forum.createdby;
                existingforum.Course_Id= forum.Course_Id;

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

        public async Task<Message<string>> Deleteforumasync(int id) {
            try
            {
                var forum = await _context.Forums.FindAsync(id);
                if(forum == null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "Error"
                    };
                }
                _context.Forums.Remove(forum);
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

        public async Task<IEnumerable<ViewForumDTO>> Getviewforumasync(int id) {
            try
            {
                var forum = await _context.Forums.Where(c => c.ForumTopic_Id == id).Select(c => new ViewForumDTO
                {
                    Course_Id= c.Course_Id,
                    createdby = c.createdby,
                    createddate = c.createddate,
                    ForumTopic = c.ForumTopic,
                    ForumTopic_Id = c.ForumTopic_Id,




                }).ToListAsync();

                return (forum);
            }
            catch (Exception ex)
            {
                throw new Exception("error");
            }
        }

        public async Task<(IEnumerable<ViewForumDTO>, int totalcount)> Getallforumasync(int page = 1, int pagesize = 5, string searchterm = "") {
            try
            { var query = _context.Forums.AsQueryable();
                if (!string.IsNullOrEmpty(searchterm))
                {
                    query = query.Where(c => c.ForumTopic.Contains(searchterm));
                }
              
                var totalcount = query.Count();
                var forum = await query.Skip((page - 1) * pagesize).Take(pagesize).Select(c => new ViewForumDTO
                {
                    Course_Id = c.Course_Id,
                    createdby = c.createdby,
                    createddate = c.createddate,
                    ForumTopic = c.ForumTopic,
                    ForumTopic_Id = c.ForumTopic_Id,
                }).ToListAsync();
                return (forum, totalcount);
            }
            catch (Exception ex)
            {
                throw new Exception("error");
            }
        }
    }
}
