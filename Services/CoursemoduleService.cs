using Learning_management_system.dbcontext;
using Learning_management_system.DTO;
using Learning_management_system.Interfaces;
using Learning_management_system.Models;
using Microsoft.EntityFrameworkCore;

namespace Learning_management_system.Services
{
    public class CoursemoduleService : ICoursemoduleService
    {
        private readonly Appdbcontext _context;

        public CoursemoduleService(Appdbcontext context)
        {

            _context = context;

        }
        public async  Task<Message<string>> CreatecoursemoduleAsync(createCoursemoduleDTO coursemoduleDTO)
        {
            try
            {
                bool ismodulenameexist = await _context.Courssemodules.AnyAsync(c=> c.Module_Name == coursemoduleDTO.Module_Name);
                if (ismodulenameexist)
                {
                    return new Message<string>
                    {
                        Status="E",
                        Text="Already exist"
                    };
                }
                var newmodule = new Courssemodules
                {
                  Module_Name= coursemoduleDTO.Module_Name,
                  Module_Description= coursemoduleDTO.Module_Description,
                  Course_Id= coursemoduleDTO.Course_Id,
                  Createddate=DateTime.Now,

                };
                 _context.Courssemodules.Add(newmodule);
                await _context.SaveChangesAsync();
                return new Message<string>
                {
                    Status= "success",
                    Text="Created successfully"


                };


            }
            catch (Exception ex)
            {
                return new Message<string>
                {
                    Status ="E",
                    Text = ex.Message,
                };
            }

        }

        public async Task<Message<string>> Updatecoursemodule(updateCoursemoduleDTO coursemoduleDTO, int id)
        {
            try
            {
                var existingmodule = await _context.Courssemodules.FindAsync(id);
                if (existingmodule != null)
                {
                    return new Message<string>
                    {
                        Status="E",
                        Text="Not found"
                    };
                }
                existingmodule.Module_Description = coursemoduleDTO.Module_Description;
                existingmodule.Module_Name = coursemoduleDTO.Module_Name;
                existingmodule.Course_Id = coursemoduleDTO.Course_Id;

                await _context.SaveChangesAsync();

                return new Message<string>
                {
                    Status="S",
                    Text="Updated successfully"
                };
               

            }
            catch (Exception ex)
            {
                return new Message<string>
                {
                    Status="E",
                    Text=ex.Message,
                };
            }

        }

        public async Task<Message<string>> deletecoursemodule(int id)
        {
            try
            {
                var module = await _context.Courssemodules.FindAsync(id);

                if (module == null)
                {
                    return new Message<string>
                    {
                        Text = "Not found"
                    };
                }
                 _context.Courssemodules.Remove(module);
                _context.SaveChanges();
                return new Message<string>
                {
                    Status="S",
                    Text = "Successfully deleted"

                };


            }
            catch (Exception ex)
            {
                return new Message<string>
                {
                    Status="E",
                    Result=ex.Message,
                    Code="500"

                };
            }

        }

        public async Task<(IEnumerable<viewCoursemoduleDTO>, int totalcount)> getallcoursemodules(int page = 1, int pagesize = 5,string searchterm="")
        {
            try
            {
                var query = _context.Courssemodules.AsQueryable();

                if(!string.IsNullOrWhiteSpace(searchterm))
                {
                    query = query.Where(c => c.Module_Name.Contains(searchterm) || c.Courses.Course_Name.Contains(searchterm));
                }

                var totalcount = await query.CountAsync();

                var modules = await query.Skip((page-1) *pagesize).Take(pagesize).Select(c=> new viewCoursemoduleDTO
                {
                    Module_Name = c.Module_Name,
                    Module_Description = c.Module_Description,
                    Module_Id = c.Module_Id,
                    Modifieddate = c.Modifieddate,
                    Createddate = c.Createddate,
                    Course_Id = c.Course_Id,
                    Course_Name= c.Courses.Course_Name


                }).ToListAsync();

                return(modules, totalcount);



            }
            catch (Exception ex)
            {
                throw new Exception("error");
            }
        }

        public async Task<IEnumerable<viewCoursemoduleDTO>> getcoursemodulebyid(int id)
        {
            try
            {
               var modules=await _context.Courssemodules.Where(c=> c.Module_Id ==id).Select(c => new viewCoursemoduleDTO
               {
                  
                   Module_Id = c.Module_Id,
                   Module_Name = c.Module_Name,
                   Modifieddate = c.Modifieddate,
                   Createddate = c.Createddate,
                   Course_Id = c.Course_Id,
                   Module_Description= c.Module_Description,
                   Course_Name=c.Courses.Course_Name

               }).ToListAsync();

                return(modules);

                




            } catch (Exception ex) {
                throw new Exception("error");
                    }

        }

      public async Task<IEnumerable<listCoursemoduleDTO>> listcoursemodule()
        {
            try
            {
                var query = _context.Courssemodules.AsQueryable();
                var coursemodules = await query.Select(c => new listCoursemoduleDTO
                {
                    Module_Id = c.Module_Id,
                    Module_Name = c.Module_Name,
                }).ToListAsync();

                return (coursemodules);


            }
            catch (Exception ex)
            {
                throw new Exception("error");
            }

        }
    }
    }

