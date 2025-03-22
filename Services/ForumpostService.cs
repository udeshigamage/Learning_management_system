using Learning_management_system.dbcontext;
using Learning_management_system.DTO;
using Learning_management_system.Interfaces;
using Learning_management_system.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Learning_management_system.Services
{
    public class ForumpostService:IForumpostservice
    {
        private readonly Appdbcontext _context;
        public ForumpostService(Appdbcontext context)
        {
            _context = context;
        }
        public async Task<Message<string>> Createforumpostasync(CreateForumpost forumpost) {
            try
            {
                var forumpost_ = new Forumposts
                {
                    postcontent = forumpost.postcontent,
                    ForumTopic_Id =forumpost.ForumTopic_Id,
                    createdby =forumpost.createdby,
                    Createddate=DateTime.UtcNow




                };
                _context.Forumposts.Add(forumpost_);
                await _context.SaveChangesAsync();
                return new Message<string>
                {
                    Status = "S",
                    Result = "Successfully created"
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

        public async Task<Message<string>> Updateforumpostasync(UpdateForumpost forumpost, int id) {
            try
            {

                var existingforumpost = await _context.Forumposts.FindAsync(id);
               if(existingforumpost == null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "Not found"
                    };
                }
               existingforumpost.postcontent = forumpost.postcontent;
                existingforumpost.ForumTopic_Id = forumpost.ForumTopic_Id;
                existingforumpost.createdby = forumpost.createdby;

               await _context.SaveChangesAsync();



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

        public async Task<Message<string>> Deleteforumpostasync(int id) {
            try
            {
                var forumpost = await _context.Forumposts.FindAsync(id);

                if(forumpost == null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "error"
                    };
                }

                _context.Forumposts.Remove(forumpost);
                await _context.SaveChangesAsync();
                return new Message<string>
                {
                    Status = "E",
                    Result = "Error"
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

        public async Task<IEnumerable<ViewForumpost>> Getviewforumpostasync(int id) {
            try
            {
                var forumpost = await _context.Forumposts.Where(c => c.Forumpost_Id == id).Select(c => new ViewForumpost
                {
                    createdby= c.createdby,
                    ForumTopic_Id = c.ForumTopic_Id,
                    Createddate = c.Createddate,
                    postcontent = c.postcontent,
                    Forumpost_Id = c.Forumpost_Id,





                }).ToListAsync();

                return forumpost;

            }
            catch (Exception ex)
            {
                throw new Exception("error");
            }
        }

        public async Task<(IEnumerable<ViewForumpost>, int totalcount)> Getallasync(int page = 1, int pagesize = 5, string searchterm = "") {
            try
            {
                var query = _context.Forumposts.AsQueryable();

                if(!string.IsNullOrEmpty(searchterm))
                {
                    query = query.Where(c => c.User.FirstName.Contains(searchterm)||c.Createddate.ToString().Contains(searchterm));
                }
                var totalcount = query.Count();
                var result = await query.Skip((page - 1) * pagesize).Take(pagesize).Select(c => new ViewForumpost
                {
                    createdby = c.createdby,
                    ForumTopic_Id = c.ForumTopic_Id,
                    Createddate = c.Createddate,
                    postcontent = c.postcontent,
                    Forumpost_Id = c.Forumpost_Id,

                }).ToListAsync();
                return (result, totalcount);
            }
            catch (Exception ex)
            {
                throw new Exception("error");
            }
        }

    }
}
